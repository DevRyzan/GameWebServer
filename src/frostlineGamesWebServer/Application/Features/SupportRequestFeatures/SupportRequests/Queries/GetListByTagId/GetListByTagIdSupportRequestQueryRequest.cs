using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;

public class GetListByTagIdSupportRequestQueryRequest : IRequest<GetListResponse<GetListByTagIdSupportRequestQueryResponse>>, ICachableRequest
{
    public GetByTagIdSupportRequestDto GetByTagIdSupportRequestDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByTagIdSupportRequestQueryRequest ({GetByTagIdSupportRequestDto.TagId},{GetByTagIdSupportRequestDto.PageRequest.Page},{GetByTagIdSupportRequestDto.PageRequest.PageSize},) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
