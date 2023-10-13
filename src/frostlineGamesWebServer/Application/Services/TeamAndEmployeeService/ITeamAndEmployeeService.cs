using Core.Persistence.Paging;
using Domain.Entities.Employees;


namespace Application.Services.TeamAndEmployeeService;

public interface ITeamAndEmployeeService
{
    Task<TeamAndEmployees> Create(TeamAndEmployees teamAndEmployee);
    Task<TeamAndEmployees> Update(TeamAndEmployees teamAndEmployee);
    Task<TeamAndEmployees> Delete(TeamAndEmployees teamAndEmployee);
    Task<TeamAndEmployees> Remove(TeamAndEmployees teamAndEmployee);
    Task<TeamAndEmployees> GetById(int id);
    Task<TeamAndEmployees> GetByEmployeeId(Guid employeeId);


    Task<TeamAndEmployees> GetByName(string name);
    Task<IEnumerable<TeamAndEmployees>> GetListByEmployeeId(Guid employeeId);


    Task<IPaginate<TeamAndEmployees>> GetByTeamIdList(int teamId, int index = 0, int size = 10);
    Task<IPaginate<TeamAndEmployees>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<TeamAndEmployees>> GetInActiveList(int index = 0, int size = 10);
    Task<IPaginate<TeamAndEmployees?>> GetListByEmployeeId(Guid? employeeId, int index = 0, int size = 10);


    #region STATUS TRUE
    Task<TeamAndEmployees> GetByIdStatusTrue(int id);
    Task<TeamAndEmployees> GetByEmployeeIdStatusTrue(Guid employeeId);
    Task<IPaginate<TeamAndEmployees>> GetByTeamIdListStatusTrue(int teamId, int index = 0, int size = 10);


    #endregion
}
