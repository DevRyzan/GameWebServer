using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;

namespace Application.Service.Repositories
{
    public interface IRefreshTokenRepository:IAsyncReadRepository<RefreshToken, int>, IReadRepository<RefreshToken, int>, IAsyncWriteRepository<RefreshToken, int>, IWriteRepository<RefreshToken, int>
    {
    }
}
