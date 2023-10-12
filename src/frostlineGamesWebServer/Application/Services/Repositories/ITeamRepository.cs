using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Employees;


namespace Application.Service.Repositories
{
    public interface ITeamRepository : IAsyncReadRepository<Team, int>, IReadRepository<Team, int>, IAsyncWriteRepository<Team, int>, IWriteRepository<Team, int>
    {
    }
}
