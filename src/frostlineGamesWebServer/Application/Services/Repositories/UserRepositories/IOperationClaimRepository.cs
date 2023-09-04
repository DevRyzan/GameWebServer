using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories.UserRepositories
{
    public interface IOperationClaimRepository : IAsyncReadRepository<OperationClaim, int>, IReadRepository<OperationClaim, int>, IAsyncWriteRepository<OperationClaim, int>, IWriteRepository<OperationClaim, int>
    {
    }
}
