using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetById;

public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQueryRequest, GetByIdTagQueryResponse>
{
    private readonly ITagService _tagService;
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdTagQueryHandler(ITagService tagService, TagBusinessRules tagBusinessRules, IMapper mapper)
    {
        _tagService = tagService;
        _tagBusinessRules = tagBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdTagQueryResponse> Handle(GetByIdTagQueryRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagIdShouldBeExist(request.GetByIdTagDto.Id);

        Tag? tag = await _tagService.GetById(request.GetByIdTagDto.Id);

        GetByIdTagQueryResponse mappedResponse = _mapper.Map<GetByIdTagQueryResponse>(tag);
        return mappedResponse;

    }
}
