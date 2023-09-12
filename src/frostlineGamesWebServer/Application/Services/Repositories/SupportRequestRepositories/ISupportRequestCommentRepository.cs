using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.SupportRequests;

namespace Application.Services.Repositories.SupportRequestRepositories;

public interface ISupportRequestCommentRepository : IAsyncReadRepository<SupportRequestComment, int>, IReadRepository<SupportRequestComment, int>, IAsyncWriteRepository<SupportRequestComment, int>, IWriteRepository<SupportRequestComment, int>
{
}
