using Core.Persistence.Paging;
using Domain.Entities.Subscriptions;
using Domain.Enums;

namespace Application.Services.SubscriptionServices;

public interface ISubscriptionService
{
    #region CRUD Services
    Task<Subscription> Create(Subscription subscription);
    Task<Subscription> Update(Subscription subscription);
    Task<Subscription> Delete(Subscription subscription);
    Task<Subscription> Remove(Subscription subscription);
    #endregion

    #region Single Value Services
    Task<Subscription> GetById(int id);

    #region Status True
    Task<Subscription> GetByIdStatusTrue(int id);
    #endregion

    #endregion

    #region List Services
    Task<IPaginate<Subscription>> GetList(int page = 0, int pageSize = 10);
    Task<IPaginate<Subscription>> GetListBySubscriptionType(SubscriptionType? subscriptionType, int page = 0, int pageSize = 10);
    Task<IPaginate<Subscription>> GetListByUserId(Guid userId, int page = 0, int pageSize = 10);
    Task<IPaginate<Subscription>> GetListByActive(int page = 0, int pageSize = 10);
    Task<IPaginate<Subscription>> GetListByInActive(int page = 0, int pageSize = 10);

    #region Status True
    Task<IPaginate<Subscription>> GetListStatusTrue(int page = 0, int pageSize = 10);
    Task<IPaginate<Subscription>> GetListByUserIdStatusTrue(Guid userId, int page = 0, int pageSize = 10);

    #endregion

    #endregion
}
