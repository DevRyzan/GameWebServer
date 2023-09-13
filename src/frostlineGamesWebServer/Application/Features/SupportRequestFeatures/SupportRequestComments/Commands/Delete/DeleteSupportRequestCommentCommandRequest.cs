using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestComments.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Delete;

public class DeleteSupportRequestCommentCommandRequest : IRequest<DeletedSupportRequestCommentResponse>, ITransactionalRequest, ICacheRemoverRequest//ISecuredRequest, 
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestCommentDelete };


    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";
}
