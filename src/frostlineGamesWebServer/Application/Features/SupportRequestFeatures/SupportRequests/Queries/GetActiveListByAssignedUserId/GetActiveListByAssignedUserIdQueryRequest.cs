using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetActiveListByAssignedUserId;

public class GetActiveListByAssignedUserIdQueryRequest : IRequest<GetListResponse<GetActiveListByAssignedUserIdQueryResponse>>, ICachableRequest
{
    public GetListByActiveListByAssignedUserIdDto GetListByActiveListByAssignedUserIdDto { get; set; }
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetActiveListByAssignedUserIdQueryRequest ({GetListByActiveListByAssignedUserIdDto.AssignedUserId},{GetListByActiveListByAssignedUserIdDto.PageRequest.Page},{GetListByActiveListByAssignedUserIdDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";

}
