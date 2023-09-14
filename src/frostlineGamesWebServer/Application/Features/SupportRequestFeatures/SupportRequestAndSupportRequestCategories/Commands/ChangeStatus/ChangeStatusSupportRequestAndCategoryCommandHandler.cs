using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.ChangeStatus;

public class ChangeStatusSupportRequestAndCategoryCommandHandler : IRequestHandler<ChangeStatusSupportRequestAndCategoryRequest, ChangeStatusSupportRequestAndCategoryResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public ChangeStatusSupportRequestAndCategoryCommandHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<ChangeStatusSupportRequestAndCategoryResponse> Handle(ChangeStatusSupportRequestAndCategoryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(request.Id);
        SupportRequestAndSupportRequestCategory? supportRequestAndCategory = await _supportRequestAndSupportRequestCategoryService.GetById(request.Id);

        supportRequestAndCategory.Status = supportRequestAndCategory.Status == true ? false : true;
        supportRequestAndCategory.UpdatedDate = DateTime.Now;

        SupportRequestAndSupportRequestCategory changedStatus = await _supportRequestAndSupportRequestCategoryService.Update(supportRequestAndCategory);

        ChangeStatusSupportRequestAndCategoryResponse mappedResponse = _mapper.Map<ChangeStatusSupportRequestAndCategoryResponse>(changedStatus);
        return mappedResponse;
    }
}

