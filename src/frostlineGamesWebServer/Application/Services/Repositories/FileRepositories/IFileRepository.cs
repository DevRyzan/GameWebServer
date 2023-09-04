using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;

using File = Domain.Entities.Files.File;

namespace Application.Service.Repositories.FileRepositories
{
    public interface IFileRepository : IAsyncReadRepository<File, int>, IReadRepository<File, int>, IAsyncWriteRepository<File, int>, IWriteRepository<File, int>
    {
    }
}
