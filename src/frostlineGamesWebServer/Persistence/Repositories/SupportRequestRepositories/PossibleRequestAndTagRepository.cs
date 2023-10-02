using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.SupportRequests;
using Persistence.Context;

namespace Persistence.Repositories.SupportRequestRepositories;

public class PossibleRequestAndTagRepository : EfRepositoryBase<PossibleRequestAndTag, int, FrostlineGamesDbContext>, IPossibleRequestAndTagRepository
{
    public PossibleRequestAndTagRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
