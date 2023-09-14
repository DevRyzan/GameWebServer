using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByStatusType;

public class GetListByStatusTypeSupportRequestQueryRequest : IRequest<GetListResponse<GetListByStatusTypeSupportRequestQueryResponse>>, ICachableRequest
{
    public GetListBySupportRequestStatusTypeDto GetListBySupportRequestStatusTypeDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByStatusTypeSupportRequestQueryRequest ({GetListBySupportRequestStatusTypeDto.SupportRequestStatusType},{GetListBySupportRequestStatusTypeDto.PageRequest.Page},{GetListBySupportRequestStatusTypeDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequests";
}
