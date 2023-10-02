using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Remove;

public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommandRequest, RemovedTagCommandResponse>
{
    private readonly ITagService _tagService;
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly IMapper _mapper;

    public RemoveTagCommandHandler(ITagService tagService, TagBusinessRules tagBusinessRules, IMapper mapper)
    {
        _tagService = tagService;
        _tagBusinessRules = tagBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemovedTagCommandResponse> Handle(RemoveTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagIdShouldBeExist(request.Id);
        Tag tag = await _tagService.GetById(request.Id);

        await _tagBusinessRules.TagStatusShouldBeFalse(tag.Id);

        await _tagService.Remove(tag);

        RemovedTagCommandResponse deletedSupportRequestDto = _mapper.Map<RemovedTagCommandResponse>(tag);
        return deletedSupportRequestDto;
    }
}
