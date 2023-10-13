using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Subscriptions;

namespace Application.Services.Repositories.SubscriptionRepositories;

public interface ISubscriptionRepository : IAsyncReadRepository<Subscription, int>, IReadRepository<Subscription, int>, IAsyncWriteRepository<Subscription, int>, IWriteRepository<Subscription, int>
{
}
