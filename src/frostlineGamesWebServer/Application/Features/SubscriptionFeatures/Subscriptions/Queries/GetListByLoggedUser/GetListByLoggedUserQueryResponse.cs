using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByLoggedUser;

public class GetListByLoggedUserQueryResponse
{

    public double Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionType subscriptionType { get; set; }
}
