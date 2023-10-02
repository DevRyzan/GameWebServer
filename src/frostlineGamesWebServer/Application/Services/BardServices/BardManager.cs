using Application.Services.Repositories.BardRepositories;
using Core.Persistence.Paging;
using Domain.Entities.Bards;

namespace Application.Services.BardServices;

public class BardManager : IBardService
{
    private readonly IBardRepository _bardRepository;

    public BardManager(IBardRepository bardRepository)
    {
        _bardRepository = bardRepository;
    }

    #region CRUD Services
    public async Task<Bard> Create(Bard bard)
    {
        Bard createdBard = await _bardRepository.AddAsync(bard);
        return createdBard;
    }
    public async Task<Bard> Delete(Bard bard)
    {
        Bard updatedBard = await _bardRepository.UpdateAsyncTrackerClear(bard);
        return updatedBard;
    }
    public async Task<Bard> Remove(Bard bard)
    {
        Bard deletedBard = await _bardRepository.DeleteAsync(bard);
        return deletedBard;
    }
    public async Task<Bard> Update(Bard bard)
    {
        Bard updatedBard = await _bardRepository.UpdateAsyncTrackerClear(bard);
        return updatedBard;
    }
    #endregion

    #region Single Value Services
    public async Task<Bard> GetById(int id)
    {
        Bard? bard = await _bardRepository.GetAsync(a => a.Id.Equals(id));
        return bard;
    }
    public async Task<Bard> GetUserByBardId(int bardId)
    {
        Bard? bard = await _bardRepository.GetAsync((_bard) => _bard.Id.Equals(bardId));
        return bard;
    }
    public async Task<Bard> GetByNickname(string nickname)
    {
        Bard bard = await _bardRepository.GetAsync(a => a.NickName == nickname);
        return bard;

    }
    public async Task<Bard> GetByUserId(Guid id)
    {
        Bard? bard = await _bardRepository.GetAsync(a => a.UserId.Equals(id));
        return bard;
    }
    public async Task<Bard> GetByMail(string mail)
    {
        var bard = await _bardRepository.GetAsync(a => a.Email == mail);
        return bard;
    }

    #region Status True
    public async Task<Bard> GetByIdByStatusTrue(int id)
    {
        Bard bard = await _bardRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return bard;
    }
    public async Task<Bard> GetByUserIdByStatusTrue(Guid userId)
    {
        Bard bard = await _bardRepository.GetAsync(x => x.UserId.Equals(userId) && x.Status == true);
        return bard;
    }
    public async Task<Bard> GetByNicknameByStatusTrue(string nickname)
    {
        Bard bard = await _bardRepository.GetAsync(x => x.NickName.Equals(nickname) && x.Status == true);
        return bard;
    }

    #endregion

    #endregion

    #region List Services
    public async Task<IPaginate<Bard>> GetList(int page = 0, int index = 10)
    {
        IPaginate<Bard> bardList = await _bardRepository.GetListAsync(page, index);
        return bardList;
    }
    public async Task<IPaginate<Bard>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<Bard> bardList = await _bardRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return bardList;
    }
    public async Task<IPaginate<Bard>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<Bard> bardList = await _bardRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return bardList;
    }
    #region Status True
    #endregion
    #endregion
}
