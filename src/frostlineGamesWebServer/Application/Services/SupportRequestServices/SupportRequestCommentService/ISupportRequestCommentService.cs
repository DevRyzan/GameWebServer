using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.SupportRequestCommentService;

public interface ISupportRequestCommentService
{
    #region CRUD Services
    Task<SupportRequestComment> Create(SupportRequestComment supportRequestComment);
    Task<SupportRequestComment> Update(SupportRequestComment supportRequestComment);
    Task<SupportRequestComment> Delete(SupportRequestComment supportRequestComment);
    Task<SupportRequestComment> Remove(SupportRequestComment supportRequestComment);
    #endregion

    #region Single Value Servcies
    Task<SupportRequestComment> GetById(int id);
    Task<SupportRequestComment> GetBySupportRequestId(int requestId);

    #region Status True
    Task<SupportRequestComment> GetByIdByStatusTrue(int id);
    Task<SupportRequestComment> GetBySupportRequestIdByStatusTrue(int supportRequestId);
    #endregion

    #endregion

    #region List Services
    Task<IPaginate<SupportRequestComment>> GetListByActive(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByInActive(int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserRole(string userRole, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserName(string userName, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListBySupportRequestId(int supportRequestId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserId(Guid userId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserIdAndSupportRequestId(Guid userId, int supportRequestId, int index = 0, int size = 10);


    #region Status True
    Task<IPaginate<SupportRequestComment>> GetListByUserRoleByStatusTrue(string userRole, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserNameByStatusTrue(string userName, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListBySupportRequestIdByStatusTrue(int supportRequestId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserIdByStatusTrue(Guid userId, int index = 0, int size = 10);
    Task<IPaginate<SupportRequestComment>> GetListByUserIdAndSupportRequestIdByStatusTrue(Guid userId, int supportRequestId, int index = 0, int size = 10);
    #endregion

    #endregion

}
