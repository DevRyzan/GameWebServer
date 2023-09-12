using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ISupportRequestCategoryRepository : IAsyncReadRepository<SupportRequestCategory, int>, IReadRepository<SupportRequestCategory, int>, IAsyncWriteRepository<SupportRequestCategory, int>, IWriteRepository<SupportRequestCategory, int>
{

}
