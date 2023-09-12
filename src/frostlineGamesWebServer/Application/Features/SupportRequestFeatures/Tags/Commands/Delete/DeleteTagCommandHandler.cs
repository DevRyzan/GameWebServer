using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Delete;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, DeletedTagCommandResponse>
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly TagBusinessRules _tagBusinessRules;

    public DeleteTagCommandHandler(ITagService tagService, IMapper mapper, TagBusinessRules tagBusinessRules)
    {
        _tagService = tagService;
        _mapper = mapper;
        _tagBusinessRules = tagBusinessRules;
    }

    public async Task<DeletedTagCommandResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagIdShouldBeExist(request.Id);
        Tag tag = await _tagService.GetById(request.Id);

        tag.Status = false;
        tag.DeletedDate = DateTime.UtcNow;

        await _tagService.Delete(tag);

        DeletedTagCommandResponse deletedSupportRequestDto = _mapper.Map<DeletedTagCommandResponse>(tag);
        return deletedSupportRequestDto;
    }
}
