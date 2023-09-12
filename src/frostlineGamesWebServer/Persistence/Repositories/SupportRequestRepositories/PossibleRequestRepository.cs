using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class PossibleRequestRepository : EfRepositoryBase<PossibleRequest, int, FrostlineGamesDbContext>, IPossibleRequestRepository
{
    public PossibleRequestRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
