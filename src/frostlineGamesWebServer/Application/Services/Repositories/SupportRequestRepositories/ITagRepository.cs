using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ITagRepository : IAsyncReadRepository<Tag, int>, IReadRepository<Tag, int>, IAsyncWriteRepository<Tag, int>, IWriteRepository<Tag, int>
{

}
