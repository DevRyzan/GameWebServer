using Application.Services.Repositories.UserRepositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.OperationClaimService
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaim> Create(OperationClaim operationClaim)
        {
            OperationClaim _operationClaim = await _operationClaimRepository.AddAsync(operationClaim);
            return _operationClaim;
        }

        public async Task<OperationClaim> Delete(OperationClaim operationClaim)
        {
            OperationClaim _operationClaim = await _operationClaimRepository.UpdateAsyncTrackerClear(operationClaim);
            return _operationClaim;
        }

        public async Task<OperationClaim> GetById(int id)
        {
            OperationClaim _operationClaim = await _operationClaimRepository.GetAsync(x => x.Id.Equals(id));
            return _operationClaim;
        }

        public async Task<OperationClaim> Remove(OperationClaim operationClaim)
        {
            OperationClaim _operationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);
            return _operationClaim;
        }

        public async Task<OperationClaim> Update(OperationClaim operationClaim)
        {
            OperationClaim _operationClaim = await _operationClaimRepository.UpdateAsyncTrackerClear(operationClaim);
            return _operationClaim;
        }
    }
}
