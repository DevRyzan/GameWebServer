using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Services.SupportRequestServices.SupportRequestCommentService;

public class SupportRequestCommentManager : ISupportRequestCommentService
{
    private readonly ISupportRequestCommentRepository _supportRequestCommentRepository;

    public SupportRequestCommentManager(ISupportRequestCommentRepository supportRequestCommentRepository)
    {
        _supportRequestCommentRepository = supportRequestCommentRepository;
    }

    #region CRUD Service
    public async Task<SupportRequestComment> Create(SupportRequestComment supportRequestComment)
    {
        SupportRequestComment _supportRequestComment = await _supportRequestCommentRepository.AddAsync(supportRequestComment);
        return _supportRequestComment;
    }
    public async Task<SupportRequestComment> Delete(SupportRequestComment supportRequestComment)
    {
        SupportRequestComment _supportRequestComment = await _supportRequestCommentRepository.UpdateAsyncTrackerClear(supportRequestComment);
        return _supportRequestComment;
    }
    public async Task<SupportRequestComment> Remove(SupportRequestComment supportRequestComment)
    {
        SupportRequestComment _supportRequestComment = await _supportRequestCommentRepository.DeleteAsync(supportRequestComment);
        return _supportRequestComment;
    }
    public async Task<SupportRequestComment> Update(SupportRequestComment supportRequestComment)
    {
        SupportRequestComment _supportRequestComment = await _supportRequestCommentRepository.UpdateAsync(supportRequestComment);
        return _supportRequestComment;
    }

    #endregion

    #region Single Value Services
    public async Task<SupportRequestComment> GetById(int id)
    {
        SupportRequestComment? supportRequestComment = await _supportRequestCommentRepository.GetAsync(a => a.Id.Equals(id));
        return supportRequestComment;
    }
    public async Task<SupportRequestComment> GetBySupportRequestId(int supportRequestId)
    {
        SupportRequestComment? supportRequestComment = await _supportRequestCommentRepository.GetAsync(a => a.SupportRequestId.Equals(supportRequestId));
        return supportRequestComment;
    }

    #region Status True

    #endregion
    #endregion

    #region List Services
    public async Task<IPaginate<SupportRequestComment>> GetListByActive(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByInActive(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserId(Guid userId, int index = 0, int size = 10)
    {
        var userSupportRequestCommentList = await _supportRequestCommentRepository.GetListAsync(x => x.UserId.Equals(userId), index: index, size: size);
        return userSupportRequestCommentList;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListBySupportRequestId(int supportRequestId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(a => a.SupportRequestId.Equals(supportRequestId), index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserIdAndSupportRequestId(Guid userId, int supportRequestId, int index = 0, int size = 10)
    {
        var userSupportRequestCommentList = await _supportRequestCommentRepository.GetListAsync(x => x.UserId.Equals(userId) && x.SupportRequestId.Equals(supportRequestId), index: index, size: size);
        return userSupportRequestCommentList;

    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserRole(string userRole, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(x => x.UserRole.Equals(userRole), index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserName(string userName, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(x => x.UserName.Equals(userName), index: index, size: size);
        return paginate;
    }

    #region Status True
    public async Task<SupportRequestComment> GetByIdByStatusTrue(int id)
    {
        SupportRequestComment? supportRequestComment = await _supportRequestCommentRepository.GetAsync(x => x.Id.Equals(id));
        return supportRequestComment;
    }
    public async Task<SupportRequestComment> GetBySupportRequestIdByStatusTrue(int supportRequestId)
    {
        SupportRequestComment supportRequestComment = await _supportRequestCommentRepository.GetAsync(x => x.SupportRequestId.Equals(supportRequestId) && x.Status == true);
        return supportRequestComment;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserRoleByStatusTrue(string userRole, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(x => x.UserRole.Equals(userRole), index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserNameByStatusTrue(string userName, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(x => x.UserName.Equals(userName) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListBySupportRequestIdByStatusTrue(int supportRequestId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestComment> paginate = await _supportRequestCommentRepository.GetListAsync(x => x.SupportRequestId.Equals(supportRequestId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserIdByStatusTrue(Guid userId, int index = 0, int size = 10)
    {
        Expression<Func<SupportRequestComment, bool>> predicate = src => src.SupportRequest.UserDetail.UserId == userId && src.Status == true;
        var userSupportRequestCommentList = await _supportRequestCommentRepository.GetListAsync(predicate: predicate, index: index, size: size);
        return userSupportRequestCommentList;

    }
    public async Task<IPaginate<SupportRequestComment>> GetListByUserIdAndSupportRequestIdByStatusTrue(Guid userId, int supportRequestId, int index = 0, int size = 10)
    {
       
        var userSupportRequestCommentList = await _supportRequestCommentRepository.GetListAsync(x => x.UserId.Equals(userId) && x.SupportRequestId.Equals(supportRequestId), index: index, size: size);
        return userSupportRequestCommentList;

    }
    #endregion
    #endregion
}

