using Application.Features.SupportRequestFeatures.Tags.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetById;

public class GetByIdTagQueryRequest : IRequest<GetByIdTagQueryResponse>, ICachableRequest
{
    public GetByIdTagDto GetByIdTagDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdTagQueryRequest ({GetByIdTagDto.Id}) ";
    public string? CacheGroupKey => "GetTags";
}
