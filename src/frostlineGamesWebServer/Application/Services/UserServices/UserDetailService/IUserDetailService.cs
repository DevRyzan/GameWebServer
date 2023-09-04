using Domain.Entities.Users; 
namespace Application.Service.UserDetailService;

public interface IUserDetailService
{
    Task<UserDetail> GetById(int id);
    Task<UserDetail> Update(UserDetail userDetail);
    Task<UserDetail> Create(UserDetail userDetail);
    Task<UserDetail> GetByUserId(Guid userId);
    Task<UserDetail> Delete(UserDetail userDetail);
    Task<UserDetail> Remove(UserDetail userDetail);

    Task<List<UserDetail>> GetListByUserIds(List<Guid> userIds);

}
