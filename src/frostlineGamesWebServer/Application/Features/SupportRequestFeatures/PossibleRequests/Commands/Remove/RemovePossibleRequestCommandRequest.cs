using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequests.Constants.OperationClaim;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;

public class RemovePossibleRequestCommandRequest : IRequest<RemovedPossibleRequestCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
 
    
    public string[] Roles => new[] { Admin, PossibleRequestRemove };




    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequests";
}
