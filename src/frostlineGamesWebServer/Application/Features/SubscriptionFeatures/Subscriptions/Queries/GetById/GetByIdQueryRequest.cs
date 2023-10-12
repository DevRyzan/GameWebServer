using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetById;

public class GetByIdQueryRequest : IRequest<GetByIdQueryResponse>, ISecuredRequest
{
    public GetByIdSubscriptionDto GetByIdSubscriptionDto { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionGetById };
}
