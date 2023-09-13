using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCommentRequest : IRequest<ChangeStatusSupportRequestCommentResponse> ,ITransactionalRequest, ICacheRemoverRequest//ISecuredRequest,  ITransactionalRequest
{
    public int Id { get; set; }

    //public string[] Roles => new[] { Admin, SupportRequestCommentChangeStatus };
    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";
}
