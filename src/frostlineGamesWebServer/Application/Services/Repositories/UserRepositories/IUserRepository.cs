using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;

namespace Application.Services.Repositories.UserRepositories;

public interface IUserRepository : IAsyncReadRepository<User, Guid>, IReadRepository<User, Guid>, IAsyncWriteRepository<User, Guid>, IWriteRepository<User, Guid>
{
}
