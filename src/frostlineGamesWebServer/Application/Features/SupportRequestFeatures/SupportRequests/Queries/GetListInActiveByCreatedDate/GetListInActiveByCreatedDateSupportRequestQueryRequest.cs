using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByCreatedDate;

public class GetListInActiveByCreatedDateSupportRequestQueryRequest : IRequest<IOrderedEnumerable<GetListInActiveByCreatedDateSupportRequestQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListInActiveByCreatedDateQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
