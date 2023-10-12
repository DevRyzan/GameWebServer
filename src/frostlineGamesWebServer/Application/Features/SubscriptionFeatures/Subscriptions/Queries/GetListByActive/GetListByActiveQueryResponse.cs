using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByActive;

public class GetListByActiveQueryResponse
{
    public Guid UserId { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionType subscriptionType { get; set; }
}
