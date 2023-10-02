using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.PossibleRequestAndTagService;

public class PossibleRequestAndTagManager : IPossibleRequestAndTagService
{
    private readonly IPossibleRequestAndTagRepository _possibleRequestAndTagRepository;

    public PossibleRequestAndTagManager(IPossibleRequestAndTagRepository possibleRequestAndTagRepository)
    {
        _possibleRequestAndTagRepository = possibleRequestAndTagRepository;
    }


    #region CRUD Services
    public async Task<PossibleRequestAndTag> Create(PossibleRequestAndTag possibleRequestAndTag)
    {
        PossibleRequestAndTag createdPossibleRequestAndTag = await _possibleRequestAndTagRepository.AddAsync(possibleRequestAndTag);
        return createdPossibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> Delete(PossibleRequestAndTag possibleRequestAndTag)
    {
        PossibleRequestAndTag updatedPossibleRequestAndTag = await _possibleRequestAndTagRepository.UpdateAsyncTrackerClear(possibleRequestAndTag);
        return updatedPossibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> Remove(PossibleRequestAndTag possibleRequestAndTag)
    {
        PossibleRequestAndTag deletedPossibleRequestAndTag = await _possibleRequestAndTagRepository.DeleteAsync(possibleRequestAndTag);
        return deletedPossibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> Update(PossibleRequestAndTag possibleRequestAndTag)
    {
        PossibleRequestAndTag updatedPossibleRequestAndTag = await _possibleRequestAndTagRepository.UpdateAsyncTrackerClear(possibleRequestAndTag);
        return updatedPossibleRequestAndTag;
    }

    #endregion

    #region Single Value Services
    public async Task<PossibleRequestAndTag> GetById(int id)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(a => a.Id.Equals(id));
        return possibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> GetByPossibleRequestId(int possibleRequestid)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync((_possibleRequestid) => _possibleRequestid.PossibleRequestId.Equals(possibleRequestid));
        return possibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> GetByTagId(int tagId)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync((_tagId) => _tagId.TagId.Equals(tagId));
        return possibleRequestAndTag;
    }

    #region Status True
    public async Task<PossibleRequestAndTag> GetByIdByStatusTrue(int id)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return possibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> GetByPossibleRequestIdByStatusTrue(int id)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(x => x.PossibleRequestId.Equals(id) && x.Status == true);
        return possibleRequestAndTag;
    }
    public async Task<PossibleRequestAndTag> GetByTagIdByStatusTrue(int tagId)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(x => x.TagId.Equals(tagId) && x.Status == true);
        return possibleRequestAndTag;
    }

    #endregion

    #endregion

    #region List Services
    public async Task<IPaginate<PossibleRequestAndTag>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> activePossibleRequestAndTagList = await _possibleRequestAndTagRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return activePossibleRequestAndTagList;
    }
    public async Task<IPaginate<PossibleRequestAndTag>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> inActivePossibleRequestAndTagList = await _possibleRequestAndTagRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return inActivePossibleRequestAndTagList;
    }
    public async Task<IPaginate<PossibleRequestAndTag>> GetActiveListByPossibleRequestId(int id, int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> activePossibleRequestAndTagList = await _possibleRequestAndTagRepository.GetListAsync(a => a.Status == true && a.PossibleRequestId.Equals(id), index: index, size: size);
        return activePossibleRequestAndTagList;
    }

    #region Status True
    public async Task<IPaginate<PossibleRequestAndTag>> GetActiveListByStatusTrue(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> paginate = await _possibleRequestAndTagRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<PossibleRequestAndTag>> GetInActiveListByStatusTrue(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> paginate = await _possibleRequestAndTagRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<PossibleRequestAndTag>> GetActiveListByPossibleRequestIdByStatusTrue(int id, int index = 0, int size = 10)
    {
        IPaginate<PossibleRequestAndTag> paginate = await _possibleRequestAndTagRepository.GetListAsync(x => x.PossibleRequestId.Equals(id), index: index, size: size);
        return paginate;
    }

    #endregion

    #endregion

}

