using Application.Service.Repositories;
using Application.Service.Repositories.FileRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.Files;
using Domain.Entities.Users;
using Persistence.Context;


namespace Persistence.Repositories.FileRepositories
{
    public class UserDetailImageFileRepository : EfRepositoryBase<UserDetailImageFile, int, FrostlineGamesDbContext>, IUserDetailImageFileRepository
    {
        public UserDetailImageFileRepository(FrostlineGamesDbContext context) : base(context)
        {
        }
    }
}
