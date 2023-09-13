using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByAssignedUserId;

public class GetListByAssignedUserIdSupportRequestQueryRequest : IRequest<GetListResponse<GetListByAssignedUserIdSupportRequestQueryResponse>>, ICachableRequest
{
    public GetListByListByAssignedUserIdDto GetListByListByAssignedUserIdDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByAssignedUserIdRequestRequest ({GetListByListByAssignedUserIdDto.AssignedUserId},{GetListByListByAssignedUserIdDto.PageRequest.Page},{GetListByListByAssignedUserIdDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
