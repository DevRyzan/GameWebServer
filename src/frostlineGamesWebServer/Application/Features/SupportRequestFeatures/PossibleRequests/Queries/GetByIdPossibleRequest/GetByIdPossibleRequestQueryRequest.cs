using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Core.Application.Caching;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdPossibleRequest;

public class GetByIdPossibleRequestQueryRequest : IRequest<GetByIdPossibleRequestQueryResponse>, ICachableRequest
{

    public Guid UserId { get; set; }
    public string? UserIP { get; set; }
    public GetByIdPossibleRequestDto GetByIdPossibleRequestDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdPossibleRequestQueryRequest ({GetByIdPossibleRequestDto.Id}) ";
    public string? CacheGroupKey => "GetPossibleRequests";
}
