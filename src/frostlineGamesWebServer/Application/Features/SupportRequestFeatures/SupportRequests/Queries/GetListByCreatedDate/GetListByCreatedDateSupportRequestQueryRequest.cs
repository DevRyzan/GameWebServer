using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByCreatedDate;

public class GetListByCreatedDateSupportRequestQueryRequest : IRequest<IOrderedEnumerable<GetListByCreatedDateSupportRequestQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByCreatedDateSupportRequestQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";

}
