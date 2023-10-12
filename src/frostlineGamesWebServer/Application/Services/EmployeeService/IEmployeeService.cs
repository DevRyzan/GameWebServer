using Domain.Entities.Employees;
using Core.Persistence.Paging;


namespace Application.Services.EmployeeService;
public interface IEmployeeService
{
    Task<Employee> Create(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Delete(Employee employee);
    Task<Employee> Remove(Employee employee);
    Task<Employee> GetById(Guid? id);
    Task<Employee> GetEmployeeUserById(Guid? id);
    Task<List<Employee>> GetListByIds(List<Guid> ids);
    Task<Employee> GetByUserId(Guid userId);
    Task<IPaginate<Employee>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<Employee>> GetInActiveList(int index = 0, int size = 10);

    Task<Employee> GetByIdByStatusTrue(Guid id);
    Task<Employee> GetByUserIdByStatusTrue(Guid userId);






    Task<Employee> GetByTeamId(int teamId);

    Task<IPaginate<Employee>> GetListBySRCategoryIdAndTeamId(int sRCategoryId, int index = 0, int size = 10);

}
