using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants.OperationClaim;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.ChangeStatus;

public class ChangeStatusPossibleRequestAndTagCommandRequest : IRequest<ChangeStatusPossibleRequestAndTagCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, PossibleRequestAndTagChangeStatus };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequestAndTags";

}
