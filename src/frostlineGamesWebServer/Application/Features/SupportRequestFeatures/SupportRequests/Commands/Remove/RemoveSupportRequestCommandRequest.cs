using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequests.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Remove;

public class RemoveSupportRequestCommandRequest : IRequest<RemoveSupportRequestCommandResponse>, ITransactionalRequest, ICacheRemoverRequest 
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, RemoveRequest };

    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequest";
}
