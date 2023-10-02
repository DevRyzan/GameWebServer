using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ISupportRequestAndSupportRequestCategoryRepository : IAsyncReadRepository<SupportRequestAndSupportRequestCategory, int>, IReadRepository<SupportRequestAndSupportRequestCategory, int>, IAsyncWriteRepository<SupportRequestAndSupportRequestCategory, int>, IWriteRepository<SupportRequestAndSupportRequestCategory, int>
{
}
