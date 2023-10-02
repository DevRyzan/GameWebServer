using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ISupportRequestRepository : IAsyncReadRepository<SupportRequest, int>, IReadRepository<SupportRequest, int>, IAsyncWriteRepository<SupportRequest, int>, IWriteRepository<SupportRequest, int>
{
}
