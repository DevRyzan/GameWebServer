using Application.Features.SupportRequestFeatures.SupportRequestComments.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using Core.Application.Transaction;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetListByActive;

public class GetListByActiveRequestCommentRequest : IRequest<GetListResponse<GetListSupportRequestCommentListModel>>, ICachableRequest, ITransactionalRequest//, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, SupportRequestCommentGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByActiveRequestCommentRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestComments";

}
