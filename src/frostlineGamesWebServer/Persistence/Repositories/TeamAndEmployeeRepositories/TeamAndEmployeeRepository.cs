using Application.Services.Repositories.TeamAndEmployeeRepositories;
using Core.Persistence.Repositories;
using Domain.Entities.Employees;
using Persistence.Context;

namespace Persistence.Repositories.TeamAndEmployeeRepositories;

public class TeamAndEmployeeRepository : EfRepositoryBase<TeamAndEmployees, int, FrostlineGamesDbContext>, ITeamAndEmployeeRepository
{
    public TeamAndEmployeeRepository(FrostlineGamesDbContext context) : base(context)
    {

    }
}
