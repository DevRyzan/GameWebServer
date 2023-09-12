using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetByIdSupportRequest;

public class GetByIdSupportRequestRequest : IRequest<GetByIdSupportRequestResponse>, ICachableRequest
{
    public GetByIdSupportRequestDto GetByIdSupportRequestDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdSupportRequestRequest ({GetByIdSupportRequestDto.Id}) ";
    public string? CacheGroupKey => "GetSupportRequests";

}
