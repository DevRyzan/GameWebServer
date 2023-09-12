using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetInActiveListByAssignedUserId;

public class GetInActiveListByAssignedUserIdQueryRequest : IRequest<GetListResponse<GetInActiveListByAssignedUserIdQueryResponse>>, ICachableRequest
{
    public GetListByInActiveListByAssignedUserIdDto GetListByInActiveListByAssignedUserIdDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetInActiveListByAssignedUserIdQueryRequest ({GetListByInActiveListByAssignedUserIdDto.AssignedUserId},{GetListByInActiveListByAssignedUserIdDto.PageRequest.Page},{GetListByInActiveListByAssignedUserIdDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
