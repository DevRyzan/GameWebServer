using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Update;

public class UpdateSubscriptionCommandResponse
{
    public string? Description { get; set; }
    public double Price { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}
