using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Update;

public class UpdateTeamAndEmployeesCommandHandler : IRequestHandler<UpdateTeamAndEmployeesCommandRequest, UpdateTeamAndEmployeesCommandResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public UpdateTeamAndEmployeesCommandHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, ITeamService teamService, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamService = teamService;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<UpdateTeamAndEmployeesCommandResponse> Handle(UpdateTeamAndEmployeesCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.EmployeeIdShouldBeExists(request.EmployeeId);
        await _teamAndEmployeesBusinessRules.TeamIdShouldBeExists(request.TeamId);

        TeamAndEmployees teamAndEmployees = await _teamAndEmployeeService.GetById(request.Id);

        teamAndEmployees.TeamId = request.TeamId;
        teamAndEmployees.EmployeeId = request.EmployeeId;
        await _teamAndEmployeeService.Update(teamAndEmployees);

        UpdateTeamAndEmployeesCommandResponse mappedEndMatchOfInventoryAndItem = _mapper.Map<UpdateTeamAndEmployeesCommandResponse>(teamAndEmployees);

        return mappedEndMatchOfInventoryAndItem;

    }
}
