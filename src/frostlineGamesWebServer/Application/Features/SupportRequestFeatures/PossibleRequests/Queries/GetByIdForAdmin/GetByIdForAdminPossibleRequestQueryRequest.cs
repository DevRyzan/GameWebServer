using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Core.Application.Caching;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdForAdmin;

public class GetByIdForAdminPossibleRequestQueryRequest : IRequest<GetByIdForAdminPossibleRequestQueryResponse>, ICachableRequest
{
    public Guid UserId { get; set; }
    public string? UserIP { get; set; }
    public GetByIdPossibleRequestDto GetByIdPossibleRequestDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdForAdminPossibleRequestQueryRequest ({GetByIdPossibleRequestDto.Id}) ";
    public string? CacheGroupKey => "GetPossibleRequests";
}
