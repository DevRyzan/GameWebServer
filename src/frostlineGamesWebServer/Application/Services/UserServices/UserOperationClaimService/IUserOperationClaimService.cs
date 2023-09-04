using Core.Security.Entities;

namespace Application.Service.UserOperationClaimService;

public interface IUserOperationClaimService
{
    Task<UserOperationClaim> Create(UserOperationClaim userOperationClaim);
    Task<UserOperationClaim> Remove(UserOperationClaim userOperationClaim);
    Task<UserOperationClaim> Delete(UserOperationClaim userOperationClaim);
    Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim);

    Task<UserOperationClaim> GetById(int id);
    Task<UserOperationClaim> GetByUserId(Guid id);
    Task<UserOperationClaim> GetByOperationClaimId(int id);


    #region STATUS TRUE
    Task<UserOperationClaim> GetByIdStatusTrue(int id);
    Task<UserOperationClaim> GetByUserIdStatusTrue(Guid id);
    Task<UserOperationClaim> GetByOperationClaimIdStatusTrue(int id);

    #endregion
}
