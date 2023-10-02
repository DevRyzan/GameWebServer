using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class SupportRequestCommentRepository : EfRepositoryBase<SupportRequestComment, int, FrostlineGamesDbContext>, ISupportRequestCommentRepository
{
    public SupportRequestCommentRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
