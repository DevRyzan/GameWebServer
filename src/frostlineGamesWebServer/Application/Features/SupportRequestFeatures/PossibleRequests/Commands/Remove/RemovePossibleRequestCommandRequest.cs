using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequests.Constants.OperationClaim;
using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;

public class RemovePossibleRequestCommandRequest : IRequest<RemovedPossibleRequestCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public RemovedPossibleRequestDto RemovedPossibleRequestDto { get; set; }

   
    public string[] Roles => new[] { Admin, PossibleRequestRemove };

    public bool BypassCache { get; }
    public string? CacheKey => $"RemovePossibleRequestCommandRequest ({RemovedPossibleRequestDto.Id} ) ";
    public string CacheGroupKey => "GetPossibleRequests";
}
