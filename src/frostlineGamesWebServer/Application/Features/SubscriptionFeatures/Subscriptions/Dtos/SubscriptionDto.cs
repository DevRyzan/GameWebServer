using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class SubscriptionDto
{
    public int Id { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public string Description { get; set; }
}
