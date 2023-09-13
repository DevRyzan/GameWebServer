using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListByPopularityPossibleRequest;

public class GetListByPopularityPossibleRequestQueryRequest : IRequest<IOrderedEnumerable<GetListByPopularityPossibleRequestQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByPopularityPossibleRequestQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequests";
}

