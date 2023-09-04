using Core.Persistence.Paging;
using Core.Security.Entities; 

namespace Application.Service.UserService;

public interface IUserService
{

    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> Delete(User user);
    Task<User> Remove(User user);

    Task<User> GetById(Guid id); 
  //  Task<User> GetByBardId(int bardId);
  //  Task<User> GetByNickName(string nickName);
    Task<User?> GetByEmail(string email);
    Task<IPaginate<User>> GetByFirstNameAndLastName(string firstName, string lastName, int index = 0, int size = 10); 
    Task<IPaginate<User>> GetList(int index = 0, int size = 10);
    Task<IPaginate<User>> GetByActiveList(int index = 0, int size = 10);
    Task<IPaginate<User>> GetByInActiveList(int index = 0, int size = 10);

    Task<List<User>> GetListByUserIds(List<Guid> ids);
    Task<User> GetByIdByStatusTrue(Guid id);
    //Task<User> GetByBardIdByStatusTrue(int barId);
    //Task<User> GetByNickNameByStatusTrue(string nickName);
    Task<User?> GetByEmailByStatusTrue(string email);
    Task<IPaginate<User>> GetByFirstNameAndLastNameByStatusTrue(string firstName, string lastName, int index = 0, int size = 10);
}
