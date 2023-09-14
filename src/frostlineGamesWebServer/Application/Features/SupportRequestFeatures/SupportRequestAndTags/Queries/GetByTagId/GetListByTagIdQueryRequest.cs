using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByTagId;

public class GetListByTagIdQueryRequest : IRequest<GetListResponse<GetListByTagIdQueryResponse>>, ICachableRequest
{
    public GetListByTagIdSupportRequestAndTagDto GetListByTagIdSupportRequestAndTagDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByTagIdQueryRequest ({GetListByTagIdSupportRequestAndTagDto.TagId},{GetListByTagIdSupportRequestAndTagDto.PageRequest.Page},{GetListByTagIdSupportRequestAndTagDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSubscriptions";
}
