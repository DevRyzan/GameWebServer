using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ISupportRequestAndTagRepository : IAsyncReadRepository<SupportRequestAndTag, int>, IReadRepository<SupportRequestAndTag, int>, IAsyncWriteRepository<SupportRequestAndTag, int>, IWriteRepository<SupportRequestAndTag, int>
{
}
