using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.SupportRequestCategoryService;

public interface ISupportRequestCategoryService
{

    #region CRUD Services
    Task<SupportRequestCategory?> Create(SupportRequestCategory? supportRequestCategory);
    Task<SupportRequestCategory?> Update(SupportRequestCategory? supportRequestCategory);
    Task<SupportRequestCategory?> Delete(SupportRequestCategory? supportRequestCategory);
    Task<SupportRequestCategory?> Remove(SupportRequestCategory? supportRequestCategory);
    #endregion

    #region Single Value Service
    Task<SupportRequestCategory?> GetById(int? id);
    Task<SupportRequestCategory?> GetByName(string name);
    #region Status True
    Task<SupportRequestCategory?> GetByIdByStatusTrue(int id);
    Task<SupportRequestCategory?> GetByNameByStatusTrue(string name);
    #endregion
    #endregion

    #region List Services
    Task<IPaginate<SupportRequestCategory>> GetList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestCategory>> GetByActiveList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestCategory>> GetByInActiveList(int index = 0, int size = 10);

    #region Status True
    #endregion

    #endregion
}
