using Application.Services.Repositories.SubscriptionRepositories;
using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using Domain.Enums;

namespace Application.Services.SubscriptionServices;

public class SubscriptionManager : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionManager(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    #region CRUD Services
    public async Task<Subscription> Create(Subscription subscription)
    {
        Subscription _subscription = await _subscriptionRepository.AddAsync(subscription);
        return _subscription;
    }
    public async Task<Subscription> Delete(Subscription subscription)
    {
        Subscription _subscription = await _subscriptionRepository.UpdateAsyncTrackerClear(subscription);
        return _subscription;
    }
    public async Task<Subscription> Remove(Subscription subscription)
    {
        Subscription _subscription = await _subscriptionRepository.DeleteAsync(subscription);
        return _subscription;
    }
    public async Task<Subscription> Update(Subscription subscription)
    {
        Subscription _subscription = await _subscriptionRepository.UpdateAsyncTrackerClear(subscription);
        return _subscription;
    }
    #endregion

    #region Single Value Services
    public async Task<Subscription> GetById(int id)
    {
        Subscription _subscription = await _subscriptionRepository.GetAsync(x => x.Id.Equals(id));
        return _subscription;
    }

    #region Status True
    public async Task<Subscription> GetByIdStatusTrue(int id)
    {
        Subscription _subscription = await _subscriptionRepository.GetAsync(x => x.Id.Equals(id) && x.Status.Equals(true));
        return _subscription;
    }
    #endregion

    #endregion

    #region List Services
    public async Task<IPaginate<Subscription>> GetList(int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(index: page, size: pageSize);
        return _subscription;
    }

    public async Task<IPaginate<Subscription>> GetListByActive(int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.Status.Equals(true), index: page, size: pageSize);
        return _subscription;
    }

    public async Task<IPaginate<Subscription>> GetListByInActive(int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.Status.Equals(false), index: page, size: pageSize);
        return _subscription;
    }

    public async Task<IPaginate<Subscription>> GetListBySubscriptionType(SubscriptionType? subscriptionType, int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.SubscriptionType.Equals(subscriptionType), index: page, size: pageSize);
        return _subscription;
    }

    public async Task<IPaginate<Subscription>> GetListByUserId(Guid userId, int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.UserId.Equals(userId), index: page, size: pageSize);
        return _subscription;
    }

    #region Status True
    public async Task<IPaginate<Subscription>> GetListStatusTrue(int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.Status.Equals(true), index: page, size: pageSize);
        return _subscription;
    }

    public async Task<IPaginate<Subscription>> GetListByUserIdStatusTrue(Guid userId, int page = 0, int pageSize = 10)
    {
        IPaginate<Subscription> _subscription = await _subscriptionRepository.GetListAsync(x => x.UserId.Equals(userId) && x.Status.Equals(true), index: page, size: pageSize);
        return _subscription;
    }
    #endregion

    #endregion
}
