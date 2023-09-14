using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequests.Constants.OperationClaim;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;

public class DeletePossibleRequestCommandRequest : IRequest<DeletedPossibleRequestCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    
    
    public string[] Roles => new[] { Admin, PossibleRequestDelete };



    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequests";
}
