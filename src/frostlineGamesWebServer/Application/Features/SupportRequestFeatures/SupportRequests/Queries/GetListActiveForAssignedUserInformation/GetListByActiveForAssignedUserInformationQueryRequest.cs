using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveForAssignedUserInformation;

public class GetListByActiveForAssignedUserInformationQueryRequest : IRequest<GetListResponse<GetListByActiveForAssignedUserInformationQueryResponse>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListByActiveForAssignedUserInformationQueryRequest ({PageRequest.Page},{PageRequest.PageSize})";

    public string? CacheGroupKey => "GetSupportRequests";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }
}
