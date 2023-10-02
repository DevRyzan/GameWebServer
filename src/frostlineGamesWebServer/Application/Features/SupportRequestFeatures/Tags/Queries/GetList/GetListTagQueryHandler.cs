using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetList;

public class GetListTagQueryHandler : IRequestHandler<GetListTagQueryRequest, GetListResponse<GetListTagQueryResponse>>
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    private readonly TagBusinessRules _tagBusinessRules;

    public GetListTagQueryHandler(ITagService tagService, IMapper mapper, TagBusinessRules tagBusinessRules)
    {
        _tagService = tagService;
        _mapper = mapper;
        _tagBusinessRules = tagBusinessRules;
    }

    public async Task<GetListResponse<GetListTagQueryResponse>> Handle(GetListTagQueryRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<Tag> tag = await _tagService.GetList(request.PageRequest.Page, request.PageRequest.PageSize);

        GetListResponse<GetListTagQueryResponse> tagListModel = _mapper.Map<GetListResponse<GetListTagQueryResponse>>(tag.Items);
        return tagListModel;
    }
}
