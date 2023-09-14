using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetList;


public class GetListSuppRequestAndCategoryHandler : IRequestHandler<GetListSuppRequestAndCategoryRequest, GetListResponse<GetListSuppRequestAndCategoryResponse>>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public GetListSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<GetListResponse<GetListSuppRequestAndCategoryResponse>> Handle(GetListSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<SupportRequestAndSupportRequestCategory> supportRequestAndSupportCategory = await _supportRequestAndSupportRequestCategoryService.GetList(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListSuppRequestAndCategoryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListSuppRequestAndCategoryResponse>>(supportRequestAndSupportCategory);

        for (int i = 0; i < supportRequestAndSupportCategory.Count; i++)
        {
            mappedResponse.Items[i].RequestId = supportRequestAndSupportCategory.Items[i].SupportRequestId;
            mappedResponse.Items[i].CategoryId = supportRequestAndSupportCategory.Items[i].SupportRequestCategoryId;
        }


        return mappedResponse;
    }
}
