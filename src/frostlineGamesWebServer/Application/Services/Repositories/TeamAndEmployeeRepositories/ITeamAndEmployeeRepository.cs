using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Employees;


namespace Application.Services.Repositories.TeamAndEmployeeRepositories;

public interface ITeamAndEmployeeRepository : IAsyncReadRepository<TeamAndEmployees, int>, IReadRepository<TeamAndEmployees, int>, IAsyncWriteRepository<TeamAndEmployees, int>, IWriteRepository<TeamAndEmployees, int>
{
}
