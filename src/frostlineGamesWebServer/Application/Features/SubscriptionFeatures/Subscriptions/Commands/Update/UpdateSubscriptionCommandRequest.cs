using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Update;

public class UpdateSubscriptionCommandRequest : IRequest<UpdateSubscriptionCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public UpdatedSubscriptionDto? UpdatedSubscriptionDto { get; set; }
    public Guid UserId { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionUpdate };
}
