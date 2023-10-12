using Application.Service.Repositories;
using Domain.Entities.Employees;
using Core.Persistence.Paging;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.SupportRequests;

namespace Application.Services.EmployeeService;
public class EmployeeManager : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITeamRepository _teamRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository, ITeamRepository teamRepository)
    {
        _employeeRepository = employeeRepository;
        _teamRepository = teamRepository;
    }

    public async Task<Employee> Create(Employee employee)
    {
        Employee createEmployee = await _employeeRepository.AddAsync(employee);
        return createEmployee;
    }
    public async Task<Employee> Delete(Employee employee)
    {
        Employee deleteEmployee = await _employeeRepository.UpdateAsync(employee);
        return deleteEmployee;
    }

    public async Task<IPaginate<Employee>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<Employee> employeeList = await _employeeRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return employeeList;
    }

    public async Task<Employee> GetById(Guid? id)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.Id.Equals(id));
        return employee;
    }
    public async Task<Employee> GetEmployeeUserById(Guid? id)
    {
        Expression<Func<Employee, bool>> predicate = x => x.Id.Equals(id);


        Employee employee = await _employeeRepository
            .GetAsync(
            predicate: predicate,
            include: a =>
           a.Include(x =>
            x.User));

        return employee;
    }
    public async Task<Employee> GetByUserId(Guid userId)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.UserId.Equals(userId));
        return employee;
    }

    public async Task<Employee> GetEmployeeByUserDetailId(Guid userId)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.UserId.Equals(userId));
        return employee;
    }

    public async Task<IPaginate<Employee>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<Employee> employeeList = await _employeeRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return employeeList;
    }

    public async Task<Employee> Remove(Employee employee)
    {
        Employee removedEmployee = await _employeeRepository.DeleteAsync(employee);
        return removedEmployee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        Employee _employee = await _employeeRepository.UpdateAsyncTrackerClear(employee);
        return _employee;
    }

    public async Task<List<Employee>> GetListByIds(List<Guid> ids)
    {
        List<Employee> list = await _employeeRepository.GetListAsyncWithOutPaginate(x => ids.Contains(x.Id));
        return list;
    }

    #region STATUS TRUE
    public async Task<Employee> GetByIdByStatusTrue(Guid id)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return employee;
    }
    public async Task<Employee> GetByUserIdByStatusTrue(Guid userId)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.UserId.Equals(userId) && x.Status == true);
        return employee;
    }



    #endregion











    public async Task<Employee> GetByTeamId(int teamId)
    {
        Expression<Func<Employee, bool>> predicate = x =>
         x.IsDeleted == false &&
         x.Status == true &&
         x.TeamAndEmployees.Any(d =>
             d.TeamId == teamId);

        Employee? employee = await _employeeRepository
            .GetAsync(
            predicate: predicate,
            include: a =>
            a.Include(x =>
            x.TeamAndEmployees));

        return employee;
    }

    public async Task<IPaginate<Employee>> GetListBySRCategoryIdAndTeamId(int sRCategoryId, int index = 0, int size = 10)
    {
        var team = await _teamRepository.GetAsync(a => a.SupportRequestCategories.Any(b => b.Id.Equals(sRCategoryId)));

        Expression<Func<Employee, bool>> predicate = x =>
        x.IsDeleted == false &&
        x.Status == true &&
        x.TeamAndEmployees.Any(d =>
            d.TeamId.Equals(team.Id));

        IPaginate<Employee>? employee = await _employeeRepository
            .GetListAsync(
            predicate: predicate,
            include: a =>
            a.Include(x =>
            x.TeamAndEmployees));

        return employee;
    }
}
