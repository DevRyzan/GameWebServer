using Core.Persistence.Paging;
using Domain.Entities.Bards;

namespace Application.Services.BardServices;

public interface IBardService
{
    #region CRUD Services
    Task<Bard> Create(Bard bard);
    Task<Bard> Update(Bard bard);
    Task<Bard> Delete(Bard bard);
    Task<Bard> Remove(Bard bard);

    #endregion

    #region Single Value Services
    Task<Bard> GetById(int id);
    Task<Bard> GetByUserId(Guid id);
    Task<Bard> GetByNickname(string nickname);
    Task<Bard> GetByMail(string mail);

    #region Status True
    Task<Bard> GetByIdByStatusTrue(int id);
    Task<Bard> GetByUserIdByStatusTrue(Guid userId);
    Task<Bard> GetByNicknameByStatusTrue(string nickname);
    #endregion

    #endregion

    #region List Services
    Task<IPaginate<Bard>> GetList(int page = 0, int index = 10);
    Task<IPaginate<Bard>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<Bard>> GetInActiveList(int index = 0, int size = 10);

    #region Status True
    #endregion
    #endregion

}
