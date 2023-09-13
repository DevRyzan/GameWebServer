using Application.Services.Repositories.BardRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.Bards;
using Persistence.Context;

namespace Persistence.Repositories.BardRepositories;

public class BardRepository : EfRepositoryBase<Bard, int, FrostlineGamesDbContext>, IBardRepository
{
    public BardRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
