using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestAndCategoryCommandHandler : IRequestHandler<RemoveSupportRequestAndCategoryCommandRequest, RemoveSupportRequestAndCategoryCommandResponse>
{
    private readonly ISupportRequestAndSupportRequestCategoryService _supportRequestAndSupportRequestCategoryService;
    private readonly IMapper _mapper;
    private readonly RequestAndCategoryBusinessRules _supportRequestAndSupportRequestCategoryBusinessRules;

    public RemoveSupportRequestAndCategoryCommandHandler(ISupportRequestAndSupportRequestCategoryService supportRequestAndSupportRequestCategoryService, IMapper mapper, RequestAndCategoryBusinessRules supportRequestAndSupportRequestCategoryBusinessRules)
    {
        _supportRequestAndSupportRequestCategoryService = supportRequestAndSupportRequestCategoryService;
        _mapper = mapper;
        _supportRequestAndSupportRequestCategoryBusinessRules = supportRequestAndSupportRequestCategoryBusinessRules;
    }

    public async Task<RemoveSupportRequestAndCategoryCommandResponse> Handle(RemoveSupportRequestAndCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(request.RemovedSupportRequestAndSupportRequestCategoryDto.Id);
        SupportRequestAndSupportRequestCategory? result = await _supportRequestAndSupportRequestCategoryService.GetById(request.RemovedSupportRequestAndSupportRequestCategoryDto.Id);

        await _supportRequestAndSupportRequestCategoryBusinessRules.SupportRequestAndSupportRequestCategoryStatusShouldBeFalse(result.Id);

        await _supportRequestAndSupportRequestCategoryService.Remove(result);

        RemoveSupportRequestAndCategoryCommandResponse mappedResponse = _mapper.Map<RemoveSupportRequestAndCategoryCommandResponse>(result);
        mappedResponse.IsRemoved = true;
        return mappedResponse;
    }
}

