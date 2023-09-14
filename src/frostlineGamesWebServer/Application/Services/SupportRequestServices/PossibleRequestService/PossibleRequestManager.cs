using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.PossibleRequestService;

public class PossibleRequestManager : IPossibleRequestService
{
    private readonly IPossibleRequestRepository _possibleRequestRepository;

    public PossibleRequestManager(IPossibleRequestRepository possibleRequestRepository)
    {
        _possibleRequestRepository = possibleRequestRepository;
    }


    #region CRUD Services
    public async Task<PossibleRequest> Create(PossibleRequest possibleRequest)
    {
        PossibleRequest createdPossibleRequest = await _possibleRequestRepository.AddAsync(possibleRequest);
        return createdPossibleRequest;
    }
    public async Task<PossibleRequest> Update(PossibleRequest possibleRequest)
    {
        PossibleRequest updatedPossibleRequest = await _possibleRequestRepository.UpdateAsyncTrackerClear(possibleRequest);
        return updatedPossibleRequest;
    }
    public async Task<PossibleRequest> Delete(PossibleRequest possibleRequest)
    {
        PossibleRequest updatedPossibleRequest = await _possibleRequestRepository.UpdateAsyncTrackerClear(possibleRequest);
        return updatedPossibleRequest;
    }
    public async Task<PossibleRequest> Remove(PossibleRequest possibleRequest)
    {
        PossibleRequest deletedPossibleRequest = await _possibleRequestRepository.DeleteAsync(possibleRequest);
        return deletedPossibleRequest;
    }
    #endregion

    #region Single Value Services
    public async Task<PossibleRequest> GetById(int id)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.Id.Equals(id));
        return possibleRequest;
    }
    public async Task<PossibleRequest> GetByName(string name)
    {
        PossibleRequest possibleRequest = await _possibleRequestRepository.GetAsync(a => a.RequestName.Equals(name));
        return possibleRequest;

    }

    #region Status True
    public async Task<PossibleRequest> GetByIdStatusTrue(int id)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.Id.Equals(id) && a.Status == true);
        return possibleRequest;
    }
    public async Task<PossibleRequest> GetByNameStatusTrue(string name)
    {
        PossibleRequest possibleRequest = await _possibleRequestRepository.GetAsync(a => a.RequestName.Equals(name) && a.Status == true);
        return possibleRequest;
    }
    #endregion
    #endregion

    #region List Services
    public async Task<IPaginate<PossibleRequest>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequest> activePossibleRequestList = await _possibleRequestRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return activePossibleRequestList;
    }
    public async Task<IPaginate<PossibleRequest>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequest> inActivePossibleRequestList = await _possibleRequestRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return inActivePossibleRequestList;
    }
    public async Task<IPaginate<PossibleRequest>> GetActiveListByPopularity(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequest> popularityPossibleRequestList = await _possibleRequestRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return popularityPossibleRequestList;
    }
    public async Task<IPaginate<PossibleRequest>> GetActiveListByCreatedDate(int index = 0, int size = 10)
    {
        IPaginate<PossibleRequest> inActivePossibleRequestList = await _possibleRequestRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return inActivePossibleRequestList;
    }
    #region Status True

    #endregion
    #endregion

}
