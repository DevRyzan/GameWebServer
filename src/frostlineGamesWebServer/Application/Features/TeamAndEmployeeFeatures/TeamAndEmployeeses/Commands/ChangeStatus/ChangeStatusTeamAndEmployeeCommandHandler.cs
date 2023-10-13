using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.ChangeStatus;

public class ChangeStatusTeamAndEmployeeCommandHandler : IRequestHandler<ChangeStatusTeamAndEmployeeCommandRequest, ChangeStatusTeamAndEmployeeCommandResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public ChangeStatusTeamAndEmployeeCommandHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, ITeamService teamService, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamService = teamService;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<ChangeStatusTeamAndEmployeeCommandResponse> Handle(ChangeStatusTeamAndEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamAndEmployeesIdShouldBeExist(request.Id);
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeeService.GetById(request.Id);

        teamAndEmployees.Status = teamAndEmployees.Status == true ? false : true;
        teamAndEmployees.UpdatedDate = DateTime.Now;

        TeamAndEmployees changedStatus = await _teamAndEmployeeService.Update(teamAndEmployees);

        ChangeStatusTeamAndEmployeeCommandResponse mappedResponse = _mapper.Map<ChangeStatusTeamAndEmployeeCommandResponse>(changedStatus);
        return mappedResponse;
    }
}