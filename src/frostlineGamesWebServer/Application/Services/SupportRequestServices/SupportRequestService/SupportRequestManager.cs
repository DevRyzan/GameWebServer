using Application.Services.Repositories.SupportRequestRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Domain.Enums;

namespace Application.Services.SupportRequestServices.SupportRequestService;

public class SupportRequestManager : ISupportRequestService
{
    private readonly ISupportRequestRepository _supportRequestRepository;
    private readonly IPossibleRequestRepository _possibleRequestRepository;
    //private readonly IEmployeeRepository _employeeRepository;

    public SupportRequestManager(ISupportRequestRepository supportRequestRepository, IPossibleRequestRepository possibleRequestRepository)
    {
        _supportRequestRepository = supportRequestRepository;
        _possibleRequestRepository = possibleRequestRepository;
    }

    #region CRUD Services
    public async Task<SupportRequest> Create(SupportRequest supportRequest)
    {
        SupportRequest? createdSupportRequest = await _supportRequestRepository.AddAsync(supportRequest);
        return createdSupportRequest;
    }
    public async Task<SupportRequest> Delete(SupportRequest supportRequest)
    {
        SupportRequest? deletedSupportRequest = await _supportRequestRepository.UpdateAsyncTrackerClear(supportRequest);
        return deletedSupportRequest;
    }
    public async Task<SupportRequest> Remove(SupportRequest supportRequest)
    {
        SupportRequest? removedSupportRequest = await _supportRequestRepository.DeleteAsync(supportRequest);
        return removedSupportRequest;
    }
    public async Task<SupportRequest> Update(SupportRequest supportRequest)
    {
        SupportRequest? updatedSupportRequest = await _supportRequestRepository.UpdateAsyncTrackerClear(supportRequest);
        return updatedSupportRequest;
    }

    #endregion

    #region Single Value Services
    public async Task<SupportRequest> GetById(int id)
    {
        SupportRequest supportRequest = await _supportRequestRepository.GetAsync(a => a.Id == id);
        return supportRequest;
    }

    #region Status True
    public async Task<SupportRequest> GetByIdStatusTrue(int id)
    {
        SupportRequest supportRequest = await _supportRequestRepository.GetAsync(a => a.Id == id && a.Status == true);
        return supportRequest;
    }
    #endregion

    #endregion

    #region List Services
    public async Task<IPaginate<SupportRequest>> GetActive()
    {
        var activeSupportRequest = await _supportRequestRepository.GetListAsync(a => a.Status == true);
        return activeSupportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListByUserId(Guid userId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest>? supportRequestList = await _supportRequestRepository.GetListAsync(predicate: a => a.UserDetail.UserId == userId, index: index, size: size);
        return supportRequestList;
    }
    public async Task<IPaginate<SupportRequest>> GetByUserId(int id)
    {
        var supportRequest = await _supportRequestRepository.GetListAsync(a => a.Id == id);
        return supportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListInActive(int index = 0, int size = 10)
    {
        var activeSupportRequest = await _supportRequestRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return activeSupportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetAll(int page = 0, int pageSize = 10)
    {
        var activeSupportRequest = await _supportRequestRepository.GetListAsync(page, pageSize);
        return activeSupportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10)
    {
        var supportRequest = await _supportRequestRepository.GetListAsync(a => a.AssignedUserId == assignedUserId, index: index, size: size);
        return supportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListActive(int index = 0, int size = 10)
    {
        var activeSupportRequest = await _supportRequestRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return activeSupportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListByPriority(SupportRequestPriority priority, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.SupportRequestPriority.Equals(priority), index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListByCreatedDate(int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListInActiveByAssignedUserId(int assignedUserId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.AssignedUserId.Equals(assignedUserId) && x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListActiveByAssignedUserId(int assignedUserId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.AssignedUserId.Equals(assignedUserId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListActiveByCreatedDate(int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListInActiveByCreatedDate(int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GeListActiveByUserDetailId(int userDetailId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.UserDetailId.Equals(userDetailId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GeListInActiveByUserDetailId(int userDetailId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.UserDetailId.Equals(userDetailId) && x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListActiveByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.AssignedUserId.Equals(assignedUserId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListInActiveByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.AssignedUserId.Equals(assignedUserId) && x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequest>> GetListByPriorityGetListByPriority(SupportRequestPriority priority, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest> paginate = await _supportRequestRepository.GetListAsync(x => x.SupportRequestPriority.Equals(priority) && x.Status == true, index: index, size: size);
        return paginate;
    }

    #region Status True
    public async Task<IPaginate<SupportRequest>> GetBySupportRequestStatusTypeAndStatusTrue(SupportRequestStatusType? supportRequestStatusType)
    {
        IPaginate<SupportRequest>? supportRequest = await _supportRequestRepository.GetListAsync(a => a.SupportRequestStatusType.Equals(supportRequestStatusType) && a.Status == true);
        return supportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetListByUserIdStatusTrue(Guid userId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequest>? supportRequestList = await _supportRequestRepository.GetListAsync(predicate: a => a.UserDetail.UserId == userId, index: index, size: size);
        return supportRequestList;
    }
    public async Task<IPaginate<SupportRequest>> GetListByAssignedUserIdStatusTrue(Guid assignedUserId, int index = 0, int size = 10)
    {
        var supportRequest = await _supportRequestRepository.GetListAsync(a => a.AssignedUserId == assignedUserId && a.Status == true, index: index, size: size);
        return supportRequest;
    }
    public async Task<IPaginate<SupportRequest>> GetAllStatusTrue(int page = 0, int pageSize = 10)
    {
        var activeSupportRequest = await _supportRequestRepository.GetListAsync(a => a.Status.Equals(true), index: page, size: pageSize);
        return activeSupportRequest;
    }

    #endregion
    #endregion

}
