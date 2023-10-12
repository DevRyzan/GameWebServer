using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Employees;
using Persistence.Context;

namespace Persistence.Repositories.TeamAndEmployeeRepositories;

public class TeamRepository : EfRepositoryBase<Team, int, FrostlineGamesDbContext>, ITeamRepository
{
    public TeamRepository(FrostlineGamesDbContext context) : base(context)
    {
    }
}
