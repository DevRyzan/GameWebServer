using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByInActive;

public class GetListByInActiveSupportRequestQueryRequest : IRequest<GetListResponse<GetListByInActiveSupportRequestQueryResponse>>, ICachableRequest 
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByInActiveSupportRequestQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
