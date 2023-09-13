using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByInActive;

public class GetListByInActiveSuppRequestAndCategoryHandler : IRequestHandler<GetListByInActiveSuppRequestAndCategoryRequest, GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse>>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public GetListByInActiveSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse>> Handle(GetListByInActiveSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportCategory = await _supportRequestAndSupportRequestCategoryService.GetInActiveList(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse>>(SupportRequestAndSupportCategory);

        return mappedResponse;
    }
}
