using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Queries.GetListByInActive;

public class GetLisByInActiveQueryResponse
{
    public Guid UserId { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionType subscriptionType { get; set; }
}
