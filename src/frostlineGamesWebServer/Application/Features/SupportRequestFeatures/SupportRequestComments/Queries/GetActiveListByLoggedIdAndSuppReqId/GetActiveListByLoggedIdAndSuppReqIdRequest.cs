using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByLoggedIdAndSuppReqId;
public class GetActiveListByLoggedIdAndSuppReqIdRequest : IRequest<GetListResponse<GetListSupportRequestCommentListModel>>, ICachableRequest
{
    public Guid UserId { get; set; }
    public string UserIp { get; set; }

    public GetListLoggedIdAndSuppRequestIdDto GetListLoggedIdAndSuppRequestIdDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetActiveListByLoggedIdAndSuppReqIdRequest ({GetListLoggedIdAndSuppRequestIdDto.SupportRequestId},{GetListLoggedIdAndSuppRequestIdDto.PageRequest.Page},{GetListLoggedIdAndSuppRequestIdDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestComments";
}
