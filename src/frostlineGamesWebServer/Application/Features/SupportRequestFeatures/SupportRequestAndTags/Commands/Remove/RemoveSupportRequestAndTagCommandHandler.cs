using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Remove;

public class RemoveSupportRequestAndTagCommandHandler : IRequestHandler<RemoveSupportRequestAndTagCommandRequest, RemoveSupportRequestAndTagCommandResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public RemoveSupportRequestAndTagCommandHandler(ISupportRequestAndTagService supportRequestAndTagService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
    }

    public SupportRequestAndTagBusinessRules SupportRequestAndTagBusinessRules => _supportRequestAndTagBusinessRules;

    public async Task<RemoveSupportRequestAndTagCommandResponse> Handle(RemoveSupportRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndTagBusinessRules.SupportRequestAndTagIdShouldExistWhenSelected(request.Id);
        await _supportRequestAndTagBusinessRules.StatusShouldBeFalse(request.Id);

        SupportRequestAndTag supportRequestAndTag = await _supportRequestAndTagService.GetById(request.Id);

        await _supportRequestAndTagBusinessRules.SupportRequestIdShouldExist(supportRequestAndTag.SupportRequestId);
        await _supportRequestAndTagBusinessRules.TagIdShouldExist(supportRequestAndTag.TagId);

        await _supportRequestAndTagService.Remove(supportRequestAndTag);

        RemoveSupportRequestAndTagCommandResponse mappedResponse = _mapper.Map<RemoveSupportRequestAndTagCommandResponse>(supportRequestAndTag);

        return mappedResponse;
    }
}
