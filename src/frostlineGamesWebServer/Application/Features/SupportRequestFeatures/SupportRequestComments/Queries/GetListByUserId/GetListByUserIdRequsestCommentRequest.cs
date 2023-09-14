using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByUserId;

public class GetListByUserIdRequsestCommentRequest : IRequest<GetListResponse<GetListSupportRequestCommentListModel>>, ICachableRequest
{
    public GetListByUserIdSupportRequestCommentDto GetListByUserIdSupportRequestCommentDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByUserIdRequsestCommentRequest ({GetListByUserIdSupportRequestCommentDto.UserId},{GetListByUserIdSupportRequestCommentDto.PageRequest.Page},{GetListByUserIdSupportRequestCommentDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestComments";
}
