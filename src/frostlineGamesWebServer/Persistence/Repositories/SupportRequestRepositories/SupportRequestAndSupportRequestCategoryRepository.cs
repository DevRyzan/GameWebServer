using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class SupportRequestAndSupportRequestCategoryRepository : EfRepositoryBase<SupportRequestAndSupportRequestCategory, int, FrostlineGamesDbContext>, ISupportRequestAndSupportRequestCategoryRepository
{
    public SupportRequestAndSupportRequestCategoryRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
