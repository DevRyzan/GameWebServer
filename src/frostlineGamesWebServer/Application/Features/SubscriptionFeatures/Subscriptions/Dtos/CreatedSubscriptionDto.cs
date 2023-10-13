using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class CreatedSubscriptionDto
{
    public double Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionType subscriptionType { get; set; }
}
