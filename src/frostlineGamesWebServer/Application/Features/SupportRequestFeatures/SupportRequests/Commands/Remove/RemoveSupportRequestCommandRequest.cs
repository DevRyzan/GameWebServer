using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequests.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Remove;

public class RemoveSupportRequestCommandRequest : IRequest<RemoveSupportRequestCommandResponse>, ITransactionalRequest, ICacheRemoverRequest 
{
    public RemovedSupportRequestDto RemovedSupportRequestDtod { get; set; }
    public string[] Roles => new[] { Admin, RemoveRequest };

    public bool BypassCache { get; }
    public string CacheKey => $"RemoveSupportRequestCommandRequest ({RemovedSupportRequestDtod.Id} ) ";
    public string? CacheGroupKey => "GetSupportRequest";
}
