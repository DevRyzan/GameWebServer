using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Subscriptions;

public class Subscription : Entity<int>
{
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public SubscriptionType SubscriptionType { get; set; }

}
