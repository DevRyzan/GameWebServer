using Application.Feature.UserFeatures.Auths.Constans;
using Application.Feature.UserFeatures.UserOperationClaims.Constans;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities; 
namespace Application.Feature.UserFeatures.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }
    public virtual async Task UserOperationClaimIdShouldExistWhenSelected(int id)
    {
        UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(UserOperationClaimMessages.UserOperationClaimNotExists);
    }

    public virtual async Task UserOperationListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(AuthMessages.PageRequestDontSuccess);

    }
    public virtual async Task UserAlreadyHaveThisRole(Guid userId,int operationClaimId)
    {
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.UserId.Equals(userId) && x.OperationClaimId.Equals(operationClaimId));
        if (userOperationClaim != null) throw new BusinessException(AuthMessages.UserAlreadyHaveThisRole);
    }
}
