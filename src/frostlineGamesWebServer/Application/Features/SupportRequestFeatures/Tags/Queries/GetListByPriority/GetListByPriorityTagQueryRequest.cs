using Application.Features.SupportRequestFeatures.Tags.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;

public class GetListByPriorityTagQueryRequest : IRequest<GetListResponse<GetListByPriorityTagQueryResponse>>, ICachableRequest
{
    public GetListByTagPriorityTagDto GetListByTagPriorityTagDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByPriorityTagQueryRequest ({GetListByTagPriorityTagDto.TagPriority},{GetListByTagPriorityTagDto.PageRequest.Page},{GetListByTagPriorityTagDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetTags";
}
