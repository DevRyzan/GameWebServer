using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByUserId;

public class GetListByUserIdSupportRequestQueryRequest : IRequest<GetListResponse<GetListByUserIdSupportRequestQueryResponse>>, ICachableRequest
{
    public GetByUserIdSupportRequestDto GetByUserIdSupportRequestDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByUserIdSupportRequestQueryRequest ({GetByUserIdSupportRequestDto.UserId},{GetByUserIdSupportRequestDto.PageRequest.Page},{GetByUserIdSupportRequestDto.PageRequest.PageSize},) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
