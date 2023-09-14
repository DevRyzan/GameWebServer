using Application.Services.Repositories.FileRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.Files;
using Persistence.Context;

namespace Persistence.Repositories.FileRepositories;

public class UserDetailImageFileRepository : EfRepositoryBase<UserDetailImageFile, int, FrostlineGamesDbContext>, IUserDetailImageFileRepository
{
    public UserDetailImageFileRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
