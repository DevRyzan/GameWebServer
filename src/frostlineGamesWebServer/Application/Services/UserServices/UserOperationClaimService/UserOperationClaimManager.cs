using Application.Services.Repositories.UserRepositories;
using Core.Security.Entities;

namespace Application.Service.UserOperationClaimService;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public Task<UserOperationClaim> Create(UserOperationClaim userOperationClaim)
    {
        throw new NotImplementedException();
    }

    public Task<UserOperationClaim> Delete(UserOperationClaim userOperationClaim)
    {
        throw new NotImplementedException();
    }

    public async Task<UserOperationClaim> GetById(int id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.Id == id);
        return userOperationClaim;
    }       

    public async Task<UserOperationClaim> GetByOperationClaimId(int id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.OperationClaimId == id);
        return userOperationClaim;
    }        

    public async Task<UserOperationClaim> GetByUserId(Guid id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.UserId == id);
        return userOperationClaim;
    }


    public Task<UserOperationClaim> Remove(UserOperationClaim userOperationClaim)
    {
        throw new NotImplementedException();
    }

    public Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim)
    {
        throw new NotImplementedException();
    }



    #region STATUS TRUE

    public async Task<UserOperationClaim> GetByIdStatusTrue(int id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.Id == id);
        return userOperationClaim;
    }

    public async Task<UserOperationClaim> GetByUserIdStatusTrue(Guid id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.UserId == id);
        return userOperationClaim;
    }
    public async Task<UserOperationClaim> GetByOperationClaimIdStatusTrue(int id)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(a => a.OperationClaimId == id);
        return userOperationClaim;
    }

    #endregion



}
