using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Entities.Employees;

namespace Application.Service.Repositories;
public interface IEmployeeRepository : IAsyncReadRepository<Employee, Guid>, IReadRepository<Employee, Guid>, IAsyncWriteRepository<Employee, Guid>, IWriteRepository<Employee, Guid>
{
}
