using Application.Feature.UserFeatures.OperationClaims.Constants;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Feature.UserFeatures.OperationClaims.Rules;

public class OperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
    }
    public virtual async Task OperationClaimIdShouldExistWhenSelected(int id)
    {
        OperationClaim? result = await _operationClaimRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(OperationClaimMessages.OperationClaimNotExists);
    }
    public virtual async Task OperationClaimNameShouldBeNotExistWhenCreated(string name)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(a => a.Name == name);
        if (operationClaim != null) throw new BusinessException(OperationClaimMessages.OperationClaimExists);
    }
    public virtual async Task OperationClaimHaveUser(int operationClaimId)
    {
        IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(x => x.OperationClaimId.Equals(operationClaimId));
        if (!userOperationClaim.Count.Equals(0)) throw new BusinessException(OperationClaimMessages.OperationClaimHaveUser);

    }
}
