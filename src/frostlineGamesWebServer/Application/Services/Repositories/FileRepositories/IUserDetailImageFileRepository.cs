using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Files;

namespace Application.Services.Repositories.FileRepositories;

public interface IUserDetailImageFileRepository : IAsyncReadRepository<UserDetailImageFile, int>,
    IReadRepository<UserDetailImageFile, int>, IAsyncWriteRepository<UserDetailImageFile, int>, IWriteRepository<UserDetailImageFile, int>
{
}
