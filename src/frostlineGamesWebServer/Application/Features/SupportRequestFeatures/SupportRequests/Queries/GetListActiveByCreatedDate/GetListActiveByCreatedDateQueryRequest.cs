using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByCreatedDate;

public class GetListActiveByCreatedDateQueryRequest : IRequest<IOrderedEnumerable<GetListActiveByCreatedDateQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }



    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListActiveByCreatedDateQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}