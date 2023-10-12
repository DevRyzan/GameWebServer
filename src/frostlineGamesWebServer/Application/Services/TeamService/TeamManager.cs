using Application.Service.Repositories;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Application.Services.TeamService;


public class TeamManager : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamManager(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    public async Task<Team> Create(Team team)
    {
        Team _team = await _teamRepository.AddAsync(team);
        return _team;
    }
    public async Task<Team> Update(Team team)
    {
        Team _team = await _teamRepository.UpdateAsyncTrackerClear(team);
        return _team;
    }
    public async Task<Team> Delete(Team team)
    {
        Team _team = await _teamRepository.UpdateAsyncTrackerClear(team);
        return _team;
    }
    public async Task<Team> Remove(Team team)
    {
        Team _team = await _teamRepository.DeleteAsync(team);
        return _team;
    }
    public async Task<IEnumerable<Team>> GetByUserId(List<int> teamIds)
    {
        IEnumerable<Team> teams = await _teamRepository.GetListAsyncWithOutPaginate(x => teamIds.Contains(x.Id));
        return teams;
    }

    //Query().AsNoTracking().Where(t => t.userId == userId).ToListAsync();
    public async Task<IPaginate<Team>> GetActiveList(int index = 0, int size = 10)
    {
        IPaginate<Team> paginate = await _teamRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<Team> GetById(int id)
    {
        Team? team = await _teamRepository.GetAsync(x => x.Id.Equals(id));
        return team;
    }
    public async Task<Team> GetByName(string name)
    {
        Team? team = await _teamRepository.GetAsync(x => x.Name.Equals(name));
        return team;
    }
    public async Task<IPaginate<Team>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<Team> paginate = await _teamRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<Team>> GetList(int index = 0, int size = 10)
    {
        IPaginate<Team> paginate = await _teamRepository.GetListAsync(index: index, size: size);
        return paginate;
    }
    public async Task<IEnumerable<Team>> GetListByTeamId(List<int> teamIds)
    {
        IEnumerable<Team> teams = await _teamRepository.GetListAsyncWithOutPaginate(x => teamIds.Contains(x.Id));
        return teams;
    }

    #region STATUS TRUE
    public async Task<Team> GetByNameByStatusTrue(string name)
    {
        Team? team = await _teamRepository.GetAsync(x => x.Name.Equals(name) && x.Status == true);
        return team;
    }
    public async Task<Team> GetByIdByStatusTrue(int id)
    {
        Team? team = await _teamRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return team;
    }



    #endregion









    public async Task<Team> GetBySupportRequestCategoryId(int supportRequestCategoryid)
    {
        Expression<Func<Team, bool>> predicate = x =>
          x.IsDeleted == false &&
          x.Status == true &&
          x.SupportRequestCategories.Any(d =>
              d.Id == supportRequestCategoryid);

        Team team = await _teamRepository
            .GetAsync(
            predicate: predicate,
            include: a =>
            a.Include(x =>
            x.SupportRequestCategories));

        return team;
    }
}
