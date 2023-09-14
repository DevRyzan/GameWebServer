using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class SupportRequestRepository : EfRepositoryBase<SupportRequest, int, FrostlineGamesDbContext>, ISupportRequestRepository
{
    public SupportRequestRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
