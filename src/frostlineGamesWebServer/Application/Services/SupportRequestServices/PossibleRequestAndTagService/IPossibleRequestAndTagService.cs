using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.PossibleRequestAndTagService;

public interface IPossibleRequestAndTagService
{
    #region CRUD Services
    Task<PossibleRequestAndTag> Create(PossibleRequestAndTag possibleRequestAndTag);
    Task<PossibleRequestAndTag> Update(PossibleRequestAndTag possibleRequestAndTag);
    Task<PossibleRequestAndTag> Delete(PossibleRequestAndTag possibleRequestAndTag);
    Task<PossibleRequestAndTag> Remove(PossibleRequestAndTag possibleRequestAndTag);
    #endregion

    #region Single Value Services
    Task<PossibleRequestAndTag> GetById(int id);
    Task<PossibleRequestAndTag> GetByPossibleRequestId(int id);
    Task<PossibleRequestAndTag> GetByTagId(int tagId);

    #region Status True
    Task<PossibleRequestAndTag> GetByIdByStatusTrue(int id);
    Task<PossibleRequestAndTag> GetByPossibleRequestIdByStatusTrue(int id);
    Task<PossibleRequestAndTag> GetByTagIdByStatusTrue(int tagId);
    #endregion
    #endregion

    #region List Services
    Task<IPaginate<PossibleRequestAndTag>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequestAndTag>> GetInActiveList(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequestAndTag>> GetActiveListByPossibleRequestId(int id, int index = 0, int size = 10);

    #region Status True
    Task<IPaginate<PossibleRequestAndTag>> GetActiveListByStatusTrue(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequestAndTag>> GetInActiveListByStatusTrue(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequestAndTag>> GetActiveListByPossibleRequestIdByStatusTrue(int id, int index = 0, int size = 10);
    #endregion

    #endregion

}
