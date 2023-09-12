using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.Repositories.SupportRequestRepositories;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Create;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
{
    private readonly ITagRepository _tagRepository;
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(ITagRepository tagRepository, TagBusinessRules tagBusinessRules, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _tagBusinessRules = tagBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagNameShouldBeNotExists(request.Name);
        Tag mappedTag = _mapper.Map<Tag>(request);

        mappedTag.Code = UIDGenerator.GenerateUID(modelName: "CREATETAG");
        mappedTag.Status = true;
        mappedTag.CreatedDate = DateTime.Now;

        await _tagRepository.AddAsync(mappedTag);

        CreateTagCommandResponse createdTagDto = _mapper.Map<CreateTagCommandResponse>(mappedTag);

        return createdTagDto;
    }
}
