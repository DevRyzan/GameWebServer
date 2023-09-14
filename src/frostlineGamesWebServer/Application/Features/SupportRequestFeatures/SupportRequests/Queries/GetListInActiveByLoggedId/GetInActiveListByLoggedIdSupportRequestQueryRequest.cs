using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByLoggedId;

public class GetInActiveListByLoggedIdSupportRequestQueryRequest : IRequest<GetListResponse<GetInActiveListByLoggedIdSupportRequestQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public Guid UserId { get; set; }
    public string CacheKey => $"GetInActiveListByLoggedIdSupportRequestQueryRequest ({UserId},{PageRequest.Page},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSupportRequest";
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
}
