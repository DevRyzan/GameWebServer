using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetList;

public class GetListTagQueryRequest :  IRequest<GetListResponse<GetListTagQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListTagQuery ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetTags";

}
