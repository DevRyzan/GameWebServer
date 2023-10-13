using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Delete;

public class DeleteSubscriptionCommandRequest : IRequest<DeleteSubscriptionCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public DeletedSubscriptionDto? DeletedSubscriptionDto { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionUpdate };
}
