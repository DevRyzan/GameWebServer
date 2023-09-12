using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Update;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommandRequest, UpdateTagCommandResponse>
{
    private readonly ITagService _tagService;
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly IMapper _mapper;

    public UpdateTagCommandHandler(ITagService tagService, TagBusinessRules tagBusinessRules, IMapper mapper)
    {
        _tagService = tagService;
        _tagBusinessRules = tagBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateTagCommandResponse> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagIdShouldBeExist(request.Id);

        Tag tag = await _tagService.GetById(request.Id);
        tag.Name = request.Name;
        tag.Description = request.Description;

        await _tagService.Update(tag);

        UpdateTagCommandResponse updatedTagDto = _mapper.Map<UpdateTagCommandResponse>(tag);
        return updatedTagDto;
    }
}
