using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestComments.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Remove;

public class RemoveSupportRequestCommentCommandRequest : IRequest<RemoveSupportRequestCommentCommandResponse>, ICacheRemoverRequest, ITransactionalRequest//ISecuredRequest, 
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCommentRemove };

    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";
}
