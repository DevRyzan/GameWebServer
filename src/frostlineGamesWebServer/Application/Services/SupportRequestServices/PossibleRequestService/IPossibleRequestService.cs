using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.PossibleRequestService;

public interface IPossibleRequestService
{

    #region CRUD Services
    Task<PossibleRequest> Create(PossibleRequest possibleRequest);
    Task<PossibleRequest> Update(PossibleRequest possibleRequest);
    Task<PossibleRequest> Delete(PossibleRequest possibleRequest);
    Task<PossibleRequest> Remove(PossibleRequest possibleRequest);
    #endregion

    #region Single Value Services
    Task<PossibleRequest> GetById(int id);
    Task<PossibleRequest> GetByName(string name);

    #region Status True
    Task<PossibleRequest> GetByIdStatusTrue(int id);
    Task<PossibleRequest> GetByNameStatusTrue(string name);
    #endregion

    #endregion

    #region List Services
    Task<IPaginate<PossibleRequest>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequest>> GetInActiveList(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequest>> GetActiveListByCreatedDate(int index = 0, int size = 10);
    Task<IPaginate<PossibleRequest>> GetActiveListByPopularity(int index = 0, int size = 10);

    #region Status True

    #endregion
    #endregion

}
