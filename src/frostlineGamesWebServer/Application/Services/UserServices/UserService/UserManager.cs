using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Paging;
using Core.Security.Entities; 

namespace Application.Service.UserService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository; 

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Create(User user)
    {
        User? _user = await _userRepository.AddAsync(user);
        return _user;
    }
    public async Task<User> Delete(User user)
    {
        User? _user = await _userRepository.UpdateAsyncTrackerClear(user);
        return _user;
    }
    public async Task<IPaginate<User>> GetByActiveList(int index = 0, int size = 10)
    {
        IPaginate<User> paginate = await _userRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<User?> GetByEmail(string email)
    {
        User? user = await _userRepository.GetAsync(x => x.Email.Equals(email));
        return user;
    }
    public async Task<IPaginate<User>> GetByFirstNameAndLastName(string firstName, string lastName, int index = 0, int size = 10)
    {
        IPaginate<User> paginate = await _userRepository.GetListAsync(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName), index: index, size: size);
        return paginate;
    } 
    public async Task<User> GetById(Guid id)
    {
        User? user = await _userRepository.GetAsync(x => x.Id.Equals(id));
        return user;
    }
    public async Task<IPaginate<User>> GetByInActiveList(int index = 0, int size = 10)
    {
        IPaginate<User> paginate = await _userRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return paginate;
    }
    //public async Task<User> GetByNickName(string nickName)
    //{
    //    Bard? bard = await _bardRepository.GetAsync(x => x.NickName.Equals(nickName));
    //    User? user = await _userRepository.GetAsync(x => x.Id.Equals(bard.UserId));
    //    return user;
    //}
    public async Task<IPaginate<User>> GetList(int index = 0, int size = 10)
    {
        IPaginate<User> paginate = await _userRepository.GetListAsync(index: index, size: size);
        return paginate;
    }
    public async Task<User> Remove(User user)
    {
        User _user = await _userRepository.DeleteAsync(user);
        return _user;
    }
    public async Task<User> Update(User user)
    {
        User _user = await _userRepository.UpdateAsync(user);
        return _user;
    }

    public async Task<List<User>> GetListByUserIds(List<Guid> ids)
    {
        List<User> userList = await _userRepository.GetListAsyncWithOutPaginate(x => ids.Contains(x.Id));
        return userList;
    }

    #region STATUS TRUE
    public async Task<User?> GetByEmailByStatusTrue(string email)
    {
        User? user = await _userRepository.GetAsync(x => x.Email.Equals(email) && x.Status == true);
        return user;
    }
    public async Task<IPaginate<User>> GetByFirstNameAndLastNameByStatusTrue(string firstName, string lastName, int index = 0, int size = 10)
    {
        IPaginate<User> paginate = await _userRepository.GetListAsync(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName), index: index, size: size);
        return paginate;
    }
    public async Task<User> GetByIdByStatusTrue(Guid id)
    {
        User? user = await _userRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return user;
    }

    public Task<User> GetByBardId(int bardId)
    {
        throw new NotImplementedException();
    }


    // public async Task<User> GetByBardIdByStatusTrue(int bardId)
    //{
    //    Bard? bard = await _bardRepository.GetAsync(x => x.Id.Equals(bardId));
    //    User? user = await _userRepository.GetAsync(x => x.Id.Equals(bard.UserId) && x.Status == true);
    //    return user;
    //}
    //public async Task<User> GetByNickNameByStatusTrue(string nickName)
    //{
    //    Bard? bard = await _bardRepository.GetAsync(x => x.NickName.Equals(nickName) && x.Status == true);
    //    User? user = await _userRepository.GetAsync(x => x.Id.Equals(bard.UserId) && x.Status == true);
    //    return user;
    //}


    #endregion
}
