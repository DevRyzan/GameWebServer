using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Core.Persistence.Paging;
using MediatR;

using static Domain.Constants.OperationClaims;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByLoggedUser;

public class GetListByLoggedUserQueryRequest : IRequest<GetListResponse<GetListByLoggedUserQueryResponse>>, ISecuredRequest
{
    public GetListByLoggedUserSubscriptionDto GetListByUserIdSubscriptionDto { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => new[] { Admin, SubscriptionGetList };
}
