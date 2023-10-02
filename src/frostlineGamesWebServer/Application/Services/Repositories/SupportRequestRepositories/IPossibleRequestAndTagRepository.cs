using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface IPossibleRequestAndTagRepository : IAsyncReadRepository<PossibleRequestAndTag, int>, IReadRepository<PossibleRequestAndTag, int>, IAsyncWriteRepository<PossibleRequestAndTag, int>, IWriteRepository<PossibleRequestAndTag, int>
{
}
