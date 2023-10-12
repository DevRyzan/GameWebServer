using Application.Services.Repositories.UserRepositories;
using Application.Services.UserServices.UserDetailService;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.Users;

namespace Application.Services.UserDetailService;

public class UserDetailManager : IUserDetailService
{
    private readonly IUserDetailRepository _userDetailRepository;

    public UserDetailManager(IUserDetailRepository userDetailRepository)
    {
        _userDetailRepository = userDetailRepository;
    }

    public async Task<UserDetail> Create(UserDetail userDetail)
    {
        UserDetail createdUserDetail = await _userDetailRepository.AddAsync(userDetail);
        return createdUserDetail;
    }

    public async Task<UserDetail> GetById(int id)
    {
        UserDetail userDetail = await _userDetailRepository.GetAsync(a => a.Id == id);
        if (userDetail == null) throw new BusinessException("The user doesn't exist.");
        return userDetail;
    }

    public async Task<UserDetail> GetByUserId(Guid userId)
    {
        UserDetail? createdUserDetail = await _userDetailRepository.GetAsync(a => a.UserId.Equals(userId));
        return createdUserDetail;
    }

    public async Task<UserDetail> Update(UserDetail userDetail)
    {
        UserDetail userdeDetail = await _userDetailRepository.UpdateAsync(userDetail);
        return userdeDetail;
    }
    public async Task<UserDetail> Delete(UserDetail userDetail)
    {
        UserDetail userdeDetail = await _userDetailRepository.DeleteAsync(userDetail);
        return userdeDetail;
    }

    public async Task<UserDetail> Remove(UserDetail userDetail)
    {
        UserDetail removedUserDetail = await _userDetailRepository.DeleteAsync(userDetail);
        return removedUserDetail;
    }

    public async Task<List<UserDetail>> GetListByUserIds(List<Guid> userIds)
    {
        List<UserDetail> userDetails = await _userDetailRepository.GetListAsyncWithOutPaginate(x => userIds.Contains((Guid)x.UserId));
        return userDetails;
    }
}
