using Application.Services.Repositories.TeamAndEmployeeRepositories;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.TeamAndEmployeeService;


public class TeamAndEmployeeManager : ITeamAndEmployeeService
{

    private readonly ITeamAndEmployeeRepository _teamAndEmployeesRepository;

    public TeamAndEmployeeManager(ITeamAndEmployeeRepository teamAndEmployeesRepository)
    {
        _teamAndEmployeesRepository = teamAndEmployeesRepository;
    }

    public async Task<TeamAndEmployees> Create(TeamAndEmployees teamAndEmployee)
    {
        var createdTeam = await _teamAndEmployeesRepository.AddAsync(teamAndEmployee);
        return createdTeam;
    }

    public async Task<TeamAndEmployees> Delete(TeamAndEmployees teamAndEmployee)
    {
        TeamAndEmployees updatedTeamAndEmployees = await _teamAndEmployeesRepository.UpdateAsyncTrackerClear(teamAndEmployee);
        return updatedTeamAndEmployees;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<TeamAndEmployees> teamAndEmployeesList = await _teamAndEmployeesRepository.GetListAsync(a => a.Status == true, index: index, size: size);
        return teamAndEmployeesList;
    }

    public async Task<TeamAndEmployees> GetByEmployeeId(Guid employeeId)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(x => x.EmployeeId.Equals(employeeId));
        return teamAndEmployees;
    }
    public Task<TeamAndEmployees> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<TeamAndEmployees> GetById(int id)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(a => a.Id.Equals(id));
        return teamAndEmployees;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetByTeamIdList(int teamId, int index = 0, int size = 10)
    {
        IPaginate<TeamAndEmployees> teamAndEmployees = await _teamAndEmployeesRepository.GetListAsync(x => x.TeamId.Equals(teamId), index: index, size: size);
        return teamAndEmployees;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<TeamAndEmployees> teamAndEmployeesList = await _teamAndEmployeesRepository.GetListAsync(a => a.Status == false, index: index, size: size);
        return teamAndEmployeesList;
    }

    public async Task<TeamAndEmployees> Remove(TeamAndEmployees teamAndEmployee)
    {
        TeamAndEmployees removedTeamAndEmployees = await _teamAndEmployeesRepository.DeleteAsync(teamAndEmployee);
        return removedTeamAndEmployees;
    }

    public async Task<TeamAndEmployees> Update(TeamAndEmployees teamAndEmployee)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.UpdateAsync(teamAndEmployee);
        return teamAndEmployees;
    }

    #region STATUS TRUE

    public async Task<TeamAndEmployees> GetByIdStatusTrue(int id)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(a => a.Id.Equals(id) && a.Status == true);
        return teamAndEmployees;
    }

    public async Task<TeamAndEmployees> GetByEmployeeIdStatusTrue(Guid employeeId)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(x => x.EmployeeId.Equals(employeeId) && x.Status == true);
        return teamAndEmployees;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetByTeamIdListStatusTrue(int teamId, int index = 0, int size = 10)
    {
        IPaginate<TeamAndEmployees> teamAndEmployees = await _teamAndEmployeesRepository.GetListAsync(x => x.TeamId.Equals(teamId) && x.Status == true, index: index, size: size);
        return teamAndEmployees;
    }

    public async Task<IEnumerable<TeamAndEmployees>> GetListByEmployeeId(Guid employeeId)
    {
        IEnumerable<TeamAndEmployees> list = await _teamAndEmployeesRepository.GetListAsyncWithOutPaginate(x => x.EmployeeId.Equals(employeeId));
        return list;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetListByEmployeeId(int employeeId, int index = 0, int size = 10)
    {
        IPaginate<TeamAndEmployees> paginate = await _teamAndEmployeesRepository.GetListAsync(x => x.EmployeeId.Equals(employeeId),
            include: t => t.Include(z => z.Employee).Include(c => c.Team).ThenInclude(v => v.SupportRequestCategories),
            index: index, size: size);

        return paginate;
    }

    public async Task<IPaginate<TeamAndEmployees>> GetListByEmployeeId(Guid? employeeId, int index = 0, int size = 10)
    {

        IPaginate<TeamAndEmployees> paginate = await _teamAndEmployeesRepository.GetListAsync(x => x
        .EmployeeId
        == employeeId,
        index: index,
        size: size,
        include: t => t.Include(v => v.Team).ThenInclude(b => b.SupportRequestCategories)
        );

        return paginate;
    }

    #endregion
}
