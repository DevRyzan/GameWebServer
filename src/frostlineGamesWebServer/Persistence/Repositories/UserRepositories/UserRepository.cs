using Application.Services.Repositories.UserRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories.UserRepositories
{
    public class UserRepository : EfRepositoryBase<User, Guid, FrostlineGamesDbContext>, IUserRepository
    {
        public UserRepository(FrostlineGamesDbContext context) : base(context)
        {

        }
    }
}
