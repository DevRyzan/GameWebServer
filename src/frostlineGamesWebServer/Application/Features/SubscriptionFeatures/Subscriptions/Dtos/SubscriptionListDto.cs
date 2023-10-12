using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Dtos;

public class SubscriptionListDto
{
    public int Id { get; set; }
    public SubscriptionType? SubscriptionType { get; set; }
}
