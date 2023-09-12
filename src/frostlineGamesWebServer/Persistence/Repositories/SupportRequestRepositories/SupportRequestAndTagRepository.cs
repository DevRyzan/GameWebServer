using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class SupportRequestAndTagRepository : EfRepositoryBase<SupportRequestAndTag, int, FrostlineGamesDbContext>, ISupportRequestAndTagRepository
{
    public SupportRequestAndTagRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
