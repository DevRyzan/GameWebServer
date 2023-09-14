using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Delete;

public class DeleteSupportRequestAndCategoryCommandHandler : IRequestHandler<DeleteSupportRequestAndCategoryCommandRequest, DeleteSupportRequestAndCategoryCommandResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public DeleteSupportRequestAndCategoryCommandHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<DeleteSupportRequestAndCategoryCommandResponse> Handle(DeleteSupportRequestAndCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(request.Id);

        SupportRequestAndSupportRequestCategory? supportRequestCategory = await _supportRequestAndSupportRequestCategoryService.GetById(request.Id);
        supportRequestCategory.Status = false;
        supportRequestCategory.DeletedDate = DateTime.UtcNow;

        await _supportRequestAndSupportRequestCategoryService.Update(supportRequestCategory);

        DeleteSupportRequestAndCategoryCommandResponse mappedResponse = _mapper.Map<DeleteSupportRequestAndCategoryCommandResponse>(supportRequestCategory);
        return mappedResponse;
    }
}
