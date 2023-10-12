using Core.Persistence.Paging;
using Domain.Entities.Employees;

namespace Application.Services.TeamService;

public interface ITeamService
{
    Task<Team> Create(Team team);
    Task<Team> Update(Team team);
    Task<Team> Delete(Team team);
    Task<Team> Remove(Team team);
    Task<Team> GetById(int id);
    Task<Team> GetBySupportRequestCategoryId(int supportRequestCategoryid);


    Task<Team> GetByName(string name);
    Task<IEnumerable<Team>> GetByUserId(List<int> teamIds);

    Task<IEnumerable<Team>> GetListByTeamId(List<int> teamIds);



    Task<IPaginate<Team>> GetList(int index = 0, int size = 10);
    Task<IPaginate<Team>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<Team>> GetInActiveList(int index = 0, int size = 10);

    Task<Team> GetByIdByStatusTrue(int id);
    Task<Team> GetByNameByStatusTrue(string name);
}
