using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByPriority;

public class GetListByPrioritySupportRequestQueryRequest : IRequest<GetListResponse<GetListByPrioritySupportRequestQueryResponse>>, ICachableRequest
{

    public GetListBySupportRequestStatusPriorityDto GetListBySupportRequestStatusPriorityDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByPrioritySupportRequestQueryRequest ({GetListBySupportRequestStatusPriorityDto.SupportRequestPriority},{GetListBySupportRequestStatusPriorityDto.PageRequest.Page},{GetListBySupportRequestStatusPriorityDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
