using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListBySupportRequestId;

public class GetListByRequestIdRequestCommentRequest : IRequest<GetListResponse<GetListSupportRequestCommentListModel>>, ICachableRequest
{
    public GetListByIdSupportRequestCommentDto GetListByIdSupportRequestCommentDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByRequestIdRequestCommentRequest ({GetListByIdSupportRequestCommentDto.SupportRequestId},{GetListByIdSupportRequestCommentDto.PageRequest.Page},{GetListByIdSupportRequestCommentDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestComments";
}
