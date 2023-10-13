using Application.Features.TeamAndEmployeeFeatures.Teams.Constants;
using Application.Service.Repositories;
using Application.Services.Repositories.TeamAndEmployeeRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities.Employees;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Rules;

public class TeamBusinessRule : BaseBusinessRules
{
    private readonly ITeamRepository _teamRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITeamAndEmployeeRepository _teamAndEmployeesRepository;
    private readonly IUserRepository _userRepository;

    public TeamBusinessRule(ITeamRepository teamRepository, IEmployeeRepository employeeRepository, IUserRepository userRepository, ITeamAndEmployeeRepository teamAndEmployeesRepository)
    {
        _teamRepository = teamRepository;
        _employeeRepository = employeeRepository;
        _userRepository = userRepository;
        _teamAndEmployeesRepository = teamAndEmployeesRepository;
    }

    public virtual async Task TeamNameShouldBeExist(string name)
    {

        Team team = await _teamRepository.GetAsync(x => x.Name.Equals(name));
        if (team == null) throw new BusinessException(TeamMessages.TeamDoesNotExist);
    }

    public virtual async Task TeamNameAlreadyShouldBeExist(string name)
    {
        Team team = await _teamRepository.GetAsync(x => x.Name.Equals(name));
        if (team != null) throw new BusinessException(TeamMessages.TeamNameAlreadyDoesExist);
    }

    public virtual async Task TeamIdShouldBeExist(int id)
    {
        Team team = await _teamRepository.GetAsync(x => x.Id.Equals(id));
        if (team == null) throw new BusinessException(TeamMessages.TeamIdDoesExist);
    }

    public virtual async Task UserIdShouldBeExist(Guid id)
    {
        User user = await _userRepository.GetAsync(x => x.Id.Equals(id));
        if (user == null) throw new BusinessException(TeamMessages.TeamIdDoesExist);
    }

    public virtual async Task UserIdShouldBeExistInEmployeeTable(Guid userId)
    {
        Employee entity = await _employeeRepository.GetAsync(x => x.UserId.Equals(userId));
        if (entity == null) throw new BusinessException(TeamMessages.TeamIdDoesExist);
    }
    public virtual async Task EmployeeShouldBeExistInTeamAndEmployeeTable(Guid employeeId)
    {
        TeamAndEmployees entity = await _teamAndEmployeesRepository.GetAsync(x => x.EmployeeId.Equals(employeeId));
        if (entity == null) throw new BusinessException(TeamMessages.EmployeeDoesExistInTeamAndEmployee);
    }

    public virtual async Task TeamsShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(TeamMessages.PageRequestDontSuccess);
    }
}
