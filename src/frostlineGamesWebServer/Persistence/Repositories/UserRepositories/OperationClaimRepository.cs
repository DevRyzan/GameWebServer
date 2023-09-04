using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories.UserRepositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, FrostlineGamesDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(FrostlineGamesDbContext context) : base(context)
    {

    }
}
