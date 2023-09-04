using Core.Security.Entities;

namespace Application.Service.OperationClaimService
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> Create(OperationClaim operationClaim);
        Task<OperationClaim> Update(OperationClaim operationClaim);
        Task<OperationClaim> Delete(OperationClaim operationClaim);
        Task<OperationClaim> Remove(OperationClaim operationClaim);
        Task<OperationClaim> GetById(int id);
    }
}
