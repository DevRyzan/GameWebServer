using Application.Features.SubscriptionFeatures.Subscriptions.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Persistence.Paging;
using MediatR;

using static Domain.Constants.OperationClaims;
using static Application.Features.SubscriptionFeatures.Subscriptions.Constants.OperationClaim;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListBySubscriptionType;

public class GetListBySubscriptionTypeQueryRequest : IRequest<GetListResponse<GetListBySubscriptionTypeQueryResponse>>, ISecuredRequest
{
    public GetListByEnumTypeSubscriptionTypeDto? GetListByEnumTypeSubscriptionTypeDto { get; set; }
    public string[] Roles => new[] { Admin, SubscriptionGetList };
}
