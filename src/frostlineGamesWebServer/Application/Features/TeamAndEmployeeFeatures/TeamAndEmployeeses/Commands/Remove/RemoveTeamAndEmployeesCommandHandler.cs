using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Remove;

public class RemoveTeamAndEmployeesCommandHandler : IRequestHandler<RemoveTeamAndEmployeesCommandRequest, RemoveTeamAndEmployeesCommandResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public RemoveTeamAndEmployeesCommandHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<RemoveTeamAndEmployeesCommandResponse> Handle(RemoveTeamAndEmployeesCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamAndEmployeesIdShouldBeExist(request.Id);

        TeamAndEmployees teamAndEmployees = await _teamAndEmployeeService.GetById(request.Id);

        await _teamAndEmployeeService.Remove(teamAndEmployees);

        RemoveTeamAndEmployeesCommandResponse mappedResponse = _mapper.Map<RemoveTeamAndEmployeesCommandResponse>(teamAndEmployees);

        return mappedResponse;
    }
}