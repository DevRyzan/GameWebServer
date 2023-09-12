using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface IPossibleRequestRepository : IAsyncReadRepository<PossibleRequest, int>, IReadRepository<PossibleRequest, int>, IAsyncWriteRepository<PossibleRequest, int>, IWriteRepository<PossibleRequest, int>
{
}
