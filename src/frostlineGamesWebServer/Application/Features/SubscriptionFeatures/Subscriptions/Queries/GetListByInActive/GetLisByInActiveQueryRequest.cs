using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

using static Domain.Constants.OperationClaims;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByInActive;

public class GetLisByInActiveQueryRequest : IRequest<GetListResponse<GetLisByInActiveQueryResponse>>, ISecuredRequest
{
    public PageRequest? PageRequest { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionGetList };
}
