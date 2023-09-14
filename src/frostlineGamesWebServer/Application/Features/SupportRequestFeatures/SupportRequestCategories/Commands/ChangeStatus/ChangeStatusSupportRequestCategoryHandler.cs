using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCategoryHandler : IRequestHandler<ChangeStatusSupportRequestCategoryRequest, ChangeStatusSupportRequestCategoryResponse>
{
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

    public ChangeStatusSupportRequestCategoryHandler(ISupportRequestCategoryService supportRequestCategoryService, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
    {
        _supportRequestCategoryService = supportRequestCategoryService;
        _mapper = mapper;
        _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
    }

    public async Task<ChangeStatusSupportRequestCategoryResponse> Handle(ChangeStatusSupportRequestCategoryRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCategoryBusinessRules.SupportRequestShouldBeExistWhenSelected(request.Id);
        SupportRequestCategory supportRequestCategory = await _supportRequestCategoryService.GetById(request.Id);

        supportRequestCategory.Status = supportRequestCategory.Status == true ? false : true;
        supportRequestCategory.UpdatedDate = DateTime.Now;

        SupportRequestCategory changedStatus = await _supportRequestCategoryService.Update(supportRequestCategory);

        ChangeStatusSupportRequestCategoryResponse mappedResponse = _mapper.Map<ChangeStatusSupportRequestCategoryResponse>(changedStatus);
        return mappedResponse;

    }
}
