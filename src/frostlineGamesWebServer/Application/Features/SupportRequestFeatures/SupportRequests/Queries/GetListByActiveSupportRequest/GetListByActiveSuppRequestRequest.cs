using Application.Features.SupportRequestFeatures.SupportRequests.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByActiveSupportRequest;

public class GetListByActiveSuppRequestRequest : IRequest<GetListResponse<GetListSupportRequestListModel>>, ICachableRequest 
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByActiveSuppRequestRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
