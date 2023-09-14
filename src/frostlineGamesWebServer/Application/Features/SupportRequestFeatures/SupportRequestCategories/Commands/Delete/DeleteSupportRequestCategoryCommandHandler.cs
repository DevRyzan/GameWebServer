using Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Delete;

public class DeleteSupportRequestCategoryCommandHandler : IRequestHandler<DeleteSupportRequestCategoryCommandRequest, DeleteSupportRequestCategoryCommandResponse>
{
    private readonly ISupportRequestCategoryService _supportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly SupportRequestCategoryBusinessRules _supportRequestCategoryBusinessRules;

    public DeleteSupportRequestCategoryCommandHandler(ISupportRequestCategoryService supportRequestCategoryService, IMapper mapper, SupportRequestCategoryBusinessRules supportRequestCategoryBusinessRules)
    {
        _supportRequestCategoryService = supportRequestCategoryService;
        _mapper = mapper;
        _supportRequestCategoryBusinessRules = supportRequestCategoryBusinessRules;
    }

    public async Task<DeleteSupportRequestCategoryCommandResponse> Handle(DeleteSupportRequestCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestCategoryBusinessRules.SupportRequestShouldBeExistWhenSelected(request.Id);

        SupportRequestCategory supportRequestCategory = await _supportRequestCategoryService.GetById(request.Id);
        supportRequestCategory.DeletedDate = DateTime.UtcNow;
        supportRequestCategory.Status = false;

        await _supportRequestCategoryService.Delete(supportRequestCategory);
        DeleteSupportRequestCategoryCommandResponse mappedResponse = _mapper.Map<DeleteSupportRequestCategoryCommandResponse>(supportRequestCategory);

        return mappedResponse;
    }
}
