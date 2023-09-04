using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;

namespace Application.Services.Repositories.UserRepositories;

public interface IUserOperationClaimRepository : IAsyncReadRepository<UserOperationClaim, int>, IReadRepository<UserOperationClaim, int>, IAsyncWriteRepository<UserOperationClaim, int>, IWriteRepository<UserOperationClaim, int>
{
}
