using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequests.Constants.OperationClaim;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;

public class UpdatePossibleRequestCommandRequest : IRequest<UpdatedPossibleRequestCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public UpdatedPossibleRequestDto UpdatedPossibleRequestDto { get; set; }

    public string[] Roles => new[] { Admin, PossibleRequestUpdate };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequests";
}
