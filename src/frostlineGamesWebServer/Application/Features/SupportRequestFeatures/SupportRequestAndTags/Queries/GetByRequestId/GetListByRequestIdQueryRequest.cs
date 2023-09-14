using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByRequestId;

public class GetListByRequestIdQueryRequest : IRequest<GetListResponse<GetListByRequestIdQueryResponse>>, ICachableRequest
{
    public GetListByRequestIdSupportRequestAndTagDto GetListByRequestIdSupportRequestAndTagDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByRequestIdQueryRequest ({GetListByRequestIdSupportRequestAndTagDto.RequestId},{GetListByRequestIdSupportRequestAndTagDto.PageRequest.Page},{GetListByRequestIdSupportRequestAndTagDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAnTags";
}
