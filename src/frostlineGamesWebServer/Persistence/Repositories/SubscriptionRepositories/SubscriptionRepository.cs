using Application.Services.Repositories.SubscriptionRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.Subscriptions;
using Persistence.Context;

namespace Persistence.Repositories.SubscriptionRepositories;

public class SubscriptionRepository : EfRepositoryBase<Subscription, int, FrostlineGamesDbContext>, ISubscriptionRepository
{
    public SubscriptionRepository(FrostlineGamesDbContext context) : base(context)
    {

    }
}
