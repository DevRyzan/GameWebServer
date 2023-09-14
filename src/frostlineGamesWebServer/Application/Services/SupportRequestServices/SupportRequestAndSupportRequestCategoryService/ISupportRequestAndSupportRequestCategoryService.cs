using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;

public interface ISupportRequestAndSupportRequestCategoryService
{
    #region CRUD Services
    Task<SupportRequestAndSupportRequestCategory> Create(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory);
    Task<SupportRequestAndSupportRequestCategory> Update(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory);
    Task<SupportRequestAndSupportRequestCategory> Delete(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory);
    Task<SupportRequestAndSupportRequestCategory> Remove(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory);
    #endregion

    #region Single Value Services
    Task<SupportRequestAndSupportRequestCategory> GetById(int id);
    Task<SupportRequestAndSupportRequestCategory> GetByRequestId(int requestId);

    #region Status True
    Task<SupportRequestAndSupportRequestCategory> GetByIdByStatusTrue(int id);
    Task<SupportRequestAndSupportRequestCategory> GetByRequestIdByStatusTrue(int requestId);
    #endregion
    #endregion

    #region List Services
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListByCategoryId(int categoryId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListBySupportRequestId(int supportRequestId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetByActiveList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetInActiveList(int index = 0, int size = 10);

    #region Status True
    Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListByCategoryIdByStatusTrue(int categoryId, int index = 0, int size = 10);
    #endregion
    #endregion
}
