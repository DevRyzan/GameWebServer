using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.ChangeStatus;

public class ChangeStatusTagCommandHandler : IRequestHandler<ChangeStatusTagCommandRequest, ChangeStatusTagCommandResponse>
{
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public ChangeStatusTagCommandHandler(TagBusinessRules tagBusinessRules, ITagService tagService, IMapper mapper)
    {
        _tagBusinessRules = tagBusinessRules;
        _tagService = tagService;
        _mapper = mapper;
    }

    public async Task<ChangeStatusTagCommandResponse> Handle(ChangeStatusTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagIdShouldBeExist(request.Id);

        Tag tag = await _tagService.GetById(request.Id);
        tag.Status = tag.Status == true ? false : true;
        tag.UpdatedDate = DateTime.UtcNow;

        await _tagService.Update(tag);

        ChangeStatusTagCommandResponse mappedResponse = _mapper.Map<ChangeStatusTagCommandResponse>(tag);
        return mappedResponse;

    }
}
