using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Create;

public class CreateSubscriptionCommandRequest : IRequest<CreateSubscriptionCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid? UserId { get; set; }
    public CreatedSubscriptionDto? CreatedSubscriptionDto { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionAdd };
}
