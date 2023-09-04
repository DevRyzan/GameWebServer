using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, FrostlineGamesDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(FrostlineGamesDbContext context) : base(context)
        {

        }
    }
}
