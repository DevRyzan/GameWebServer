using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Employees;
using Persistence.Context;

namespace Persistence.Repositories.TeamAndEmployeeRepositories;

public class EmployeeRepository : EfRepositoryBase<Employee, Guid, FrostlineGamesDbContext>, IEmployeeRepository
{
    public EmployeeRepository(FrostlineGamesDbContext context) : base(context)
    {

    }
}
