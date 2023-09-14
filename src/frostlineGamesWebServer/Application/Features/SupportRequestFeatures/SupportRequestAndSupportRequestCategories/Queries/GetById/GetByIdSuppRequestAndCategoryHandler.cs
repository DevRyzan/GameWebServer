using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetById;

public class GetByIdSuppRequestAndCategoryHandler : IRequestHandler<GetByIdSuppRequestAndCategoryRequest, GetByIdSuppRequestAndCategoryResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public GetByIdSuppRequestAndCategoryHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules, ISupportRequestService supportRequestService, ISupportRequestCategoryService supportRequestCategoryService)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
        _supportRequestService = supportRequestService;
        _supportRequestCategoryService = supportRequestCategoryService;
    }

    public async Task<GetByIdSuppRequestAndCategoryResponse> Handle(GetByIdSuppRequestAndCategoryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(request.GetByIdSupportRequestAndCategoryDto.Id);
        SupportRequestAndSupportRequestCategory? supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryService.GetById(request.GetByIdSupportRequestAndCategoryDto.Id);

        var supportRequest = await _supportRequestService.GetById(supportRequestAndSupportRequestCategory.SupportRequestId);
        var supportRequestCategory = await _supportRequestCategoryService.GetById(supportRequestAndSupportRequestCategory.SupportRequestCategoryId);

        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestIdShouldBeExist(supportRequest.Id);
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestCategoryIdShouldBeExist(supportRequestCategory.Id);

        GetByIdSuppRequestAndCategoryResponse mappedResponse = _mapper.Map<GetByIdSuppRequestAndCategoryResponse>(supportRequestAndSupportRequestCategory);
        mappedResponse.SupportRequestTitle = supportRequest.SupportRequestTitle;
        mappedResponse.SupportRequestComment = supportRequest.SupportRequestCoomment;
        mappedResponse.SupportRequestCategoryName = supportRequestCategory.Name;

        return mappedResponse;
    }
}
