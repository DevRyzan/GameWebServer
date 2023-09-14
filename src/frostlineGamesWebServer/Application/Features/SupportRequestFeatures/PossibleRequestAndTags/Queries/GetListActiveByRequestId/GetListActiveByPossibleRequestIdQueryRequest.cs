using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActiveByRequestId;

public class GetListActiveByPossibleRequestIdQueryRequest : IRequest<GetListResponse<GetListActiveByPossibleRequestIdQueryResponse>>, ICachableRequest
{
    public GetListByPossibleRequestIdPossibleRequestAndTagDto getListByPossibleRequestIdPossibleRequestAndTagDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListActiveByPossibleRequestIdQueryRequest ({getListByPossibleRequestIdPossibleRequestAndTagDto.PossibleRequestId},{getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.Page},{getListByPossibleRequestIdPossibleRequestAndTagDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";

}
