using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetActiveListByUserIdAndSuppRequestId;

public class GetActiveListByUserIdAndSuppRequestIdRequest : IRequest<GetListResponse<GetListSupportRequestCommentListModel>>, ICachableRequest
{
    public GetListByUserIdAndSuppRequestIdDto GetListByUserIdAndSuppRequestIdDto { get; set; }

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetActiveListByUserIdAndSuppRequestIdRequest ({GetListByUserIdAndSuppRequestIdDto.UserId},{GetListByUserIdAndSuppRequestIdDto.SupportRequestId},{GetListByUserIdAndSuppRequestIdDto.PageRequest.Page},{GetListByUserIdAndSuppRequestIdDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestComments";
}
