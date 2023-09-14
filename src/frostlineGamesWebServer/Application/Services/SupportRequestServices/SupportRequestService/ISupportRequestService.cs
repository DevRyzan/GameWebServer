using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Domain.Enums;

namespace Application.Services.SupportRequestServices.SupportRequestService;

public interface ISupportRequestService
{

    #region CRUD Services
    Task<SupportRequest> Create(SupportRequest supportRequest);
    Task<SupportRequest> Update(SupportRequest supportRequest);
    Task<SupportRequest> Delete(SupportRequest supportRequest);
    Task<SupportRequest> Remove(SupportRequest supportRequest);
    #endregion

    #region Single Value Services
    Task<SupportRequest> GetById(int id);
    //Task<SupportRequestCountDto> GetByCount();

    #region Status True

    #endregion
    #endregion

    #region List Services
    Task<IPaginate<SupportRequest>> GetListByPriority(SupportRequestPriority priority, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListActiveByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListByCreatedDate(int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListInActiveByCreatedDate(int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListActiveByCreatedDate(int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListInActiveByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListByUserId(Guid userId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListByAssignedUserId(Guid assignedUserId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetAll(int page = 0, int pageSize = 10);
    Task<IPaginate<SupportRequest>> GetListActive(int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListInActive(int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetByUserId(int id);
    Task<IPaginate<SupportRequest>> GeListActiveByUserDetailId(int userDetailId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GeListInActiveByUserDetailId(int userDetailId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListByPriorityGetListByPriority(SupportRequestPriority priority, int index = 0, int size = 10);

    #region Status True
    Task<IPaginate<SupportRequest>> GetBySupportRequestStatusTypeAndStatusTrue(SupportRequestStatusType? supportRequestStatusType);
    Task<SupportRequest> GetByIdStatusTrue(int id);
    Task<IPaginate<SupportRequest>> GetListByUserIdStatusTrue(Guid userId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetListByAssignedUserIdStatusTrue(Guid assignedUserId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequest>> GetAllStatusTrue(int page = 0, int pageSize = 10);
    #endregion
    #endregion
}
