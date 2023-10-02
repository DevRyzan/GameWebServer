using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetById;

public class GetByIdRequestAndTagQueryRequest : IRequest<GetByIdRequestAndTagQueryResponse>, ICachableRequest
{
    public GetByIdSupportRequestAnTagDto GetByIdSupportRequestAnTagDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdRequestAndTagQueryRequest ({GetByIdSupportRequestAnTagDto.Id}) ";
    public string? CacheGroupKey => "GetSupportRequestAnTags";
}
