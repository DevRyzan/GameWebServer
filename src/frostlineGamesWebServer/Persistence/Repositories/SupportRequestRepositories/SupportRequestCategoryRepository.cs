using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class SupportRequestCategoryRepository : EfRepositoryBase<SupportRequestCategory, int, FrostlineGamesDbContext>, ISupportRequestCategoryRepository
{
    public SupportRequestCategoryRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
