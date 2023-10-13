using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants;
using Application.Service.Repositories;
using Application.Services.Repositories.TeamAndEmployeeRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.Employees;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;

public class TeamAndEmployeesBusinessRules : BaseBusinessRules
{
    private readonly ITeamAndEmployeeRepository _teamAndEmployeesRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public TeamAndEmployeesBusinessRules(ITeamAndEmployeeRepository teamAndEmployeesRepository, ITeamRepository teamRepository, IEmployeeRepository employeeRepository)
    {
        _teamAndEmployeesRepository = teamAndEmployeesRepository;
        _teamRepository = teamRepository;
        _employeeRepository = employeeRepository;
    }

    public virtual async Task TeamAndEmployeesIdShouldBeExist(int id)
    {
        var teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(a => a.Id.Equals(id));
        if (teamAndEmployees == null) throw new BusinessException(TeamAndEmployeeMessages.TeamAndEmployeesDoesNotExist);
    }
    public async Task TeamIdShouldBeExists(int teamId)
    {
        Team team = await _teamRepository.GetAsync(a => a.Id.Equals(teamId));
        if (team is null) throw new BusinessException(TeamAndEmployeeMessages.TeamDoesNotExist);
    }
    public async Task EmployeeIdShouldBeExists(Guid employeeId)
    {
        Employee employee = await _employeeRepository.GetAsync(a => a.Id.Equals(employeeId));
        if (employee is null) throw new BusinessException(TeamAndEmployeeMessages.EmployeeDoesNotExist);
    }
    public async Task EmployeeShouldBeNotExistsWhenTeamAndEmployeeExist(Guid employeeId)
    {
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeesRepository.GetAsync(a => a.EmployeeId.Equals(employeeId));
        if (teamAndEmployees is not null) throw new BusinessException(TeamAndEmployeeMessages.EmployeeAlreadyExist);
    }
    public virtual async Task TeamAndEmployeesShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(TeamAndEmployeeMessages.PageRequestDontSuccess);
    }
}
