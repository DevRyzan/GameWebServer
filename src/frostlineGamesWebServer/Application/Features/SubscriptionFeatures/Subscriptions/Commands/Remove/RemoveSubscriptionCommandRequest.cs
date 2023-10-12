namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Remove;
using static Domain.Constants.OperationClaims;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class RemoveSubscriptionCommandRequest : IRequest<RemoveSubscriptionCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public RemovedSubscriptionDto? RemovedSubscriptionDto { get; set; }

    public string[] Roles => new[] { Admin, SubscriptionRemove };
}
