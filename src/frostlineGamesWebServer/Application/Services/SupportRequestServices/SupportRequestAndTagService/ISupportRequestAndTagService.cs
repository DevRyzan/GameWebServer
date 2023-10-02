using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.SupportRequestAndTagService;

public interface ISupportRequestAndTagService
{
    #region CRUD Services
    Task<SupportRequestAndTag> Create(SupportRequestAndTag supportRequestAndTag);
    Task<List<SupportRequestAndTag>> CreateList(List<SupportRequestAndTag> supportRequestAndTagList);
    Task<SupportRequestAndTag> Update(SupportRequestAndTag supportRequestAndTag);
    Task<SupportRequestAndTag> Delete(SupportRequestAndTag supportRequestAndTag);
    Task<SupportRequestAndTag> Remove(SupportRequestAndTag supportRequestAndTag);
    #endregion

    #region Single Value Services
    Task<SupportRequestAndTag> GetById(int id);

    #region Status True
    Task<SupportRequestAndTag> GetByIdByStatusTrue(int id);
    #endregion
    #endregion

    #region List Services
    Task<IPaginate<SupportRequestAndTag>> GetListByTagId(int tagId, int index = 0, int size = 10);
    Task<List<SupportRequestAndTag>> GetListByTagIdWithoutPaginate(int tagId);
    Task<IPaginate<SupportRequestAndTag>> GetListByRequestId(int requestId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndTag>> GetList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndTag>> GetByActiveList(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndTag>> GetByInActiveList(int index = 0, int size = 10);
    Task<List<SupportRequestAndTag>> GetListByRequestId(int requestId);

    #region Status True
    Task<IPaginate<SupportRequestAndTag>> GetListByTagIdByStatusTrue(int tagId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestAndTag>> GetListByRequestIdByStatusTrue(int requestId, int index = 0, int size = 10);
    #endregion

    #endregion

}
