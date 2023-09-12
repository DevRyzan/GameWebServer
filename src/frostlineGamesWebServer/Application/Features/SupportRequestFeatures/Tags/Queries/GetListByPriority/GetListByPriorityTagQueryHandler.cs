using Application.Features.SupportRequestFeatures.Tags.Rules;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;

public class GetListByPriorityTagQueryHandler : IRequestHandler<GetListByPriorityTagQueryRequest, GetListResponse<GetListByPriorityTagQueryResponse>>
{
    private readonly ITagService _tagService;
    private readonly TagBusinessRules _tagBusinessRules;
    private readonly IMapper _mapper;

    public GetListByPriorityTagQueryHandler(ITagService tagService, TagBusinessRules tagBusinessRules, IMapper mapper)
    {
        _tagService = tagService;
        _tagBusinessRules = tagBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListByPriorityTagQueryResponse>> Handle(GetListByPriorityTagQueryRequest request, CancellationToken cancellationToken)
    {
        await _tagBusinessRules.TagListShouldBeListedWhenSelected(request.GetListByTagPriorityTagDto.PageRequest.Page, request.GetListByTagPriorityTagDto.PageRequest.PageSize);

        IPaginate<Tag> tag = await _tagService.GetListByTagPriority(request.GetListByTagPriorityTagDto.TagPriority, request.GetListByTagPriorityTagDto.PageRequest.Page, request.GetListByTagPriorityTagDto.PageRequest.PageSize);

        GetListResponse<GetListByPriorityTagQueryResponse> tagListModel = _mapper.Map<GetListResponse<GetListByPriorityTagQueryResponse>>(tag);
        return tagListModel;
    }
}
