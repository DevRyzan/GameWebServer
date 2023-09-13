using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetById;

public class GetByIdSupportRequestQueryRequest : IRequest<GetByIdSupportRequestQueryResponse>, ICachableRequest
{
    public GetByIdSupportRequestDto GetByIdSupportRequestDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdSupportRequestRequest ({GetByIdSupportRequestDto.Id}) ";
    public string? CacheGroupKey => "GetSupportRequests";

}
