using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Commands.Remove;

public class RemoveSubscriptionCommandResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public SubscriptionType subscriptionType { get; set; }
}
