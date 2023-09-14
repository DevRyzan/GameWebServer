using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Bards;

namespace Application.Services.Repositories.BardRepositories;

public interface IBardRepository : IAsyncReadRepository<Bard, int>, IReadRepository<Bard, int>, IAsyncWriteRepository<Bard, int>, IWriteRepository<Bard, int>
{
}
