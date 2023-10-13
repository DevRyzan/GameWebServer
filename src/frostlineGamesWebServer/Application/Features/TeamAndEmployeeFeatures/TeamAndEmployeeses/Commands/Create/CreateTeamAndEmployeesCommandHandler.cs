using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;

public class CreateTeamAndEmployeesCommandHandler : IRequestHandler<CreateTeamAndEmployeesCommandRequest, CreatedTeamAndEmployeesCommandResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;
    private readonly IRandomCodeGenerator _randomCodeGenerator;
    public CreateTeamAndEmployeesCommandHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules, IRandomCodeGenerator randomCodeGenerator)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
        _randomCodeGenerator = randomCodeGenerator;
    }

    public async Task<CreatedTeamAndEmployeesCommandResponse> Handle(CreateTeamAndEmployeesCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamIdShouldBeExists(teamId: request.TeamId);
        await _teamAndEmployeesBusinessRules.EmployeeIdShouldBeExists(employeeId: request.EmployeeId);
        await _teamAndEmployeesBusinessRules.EmployeeShouldBeNotExistsWhenTeamAndEmployeeExist(employeeId: request.EmployeeId);

        var mappedTeamAndEmployees = _mapper.Map<TeamAndEmployees>(request);
        mappedTeamAndEmployees.Status = true;
        mappedTeamAndEmployees.Code = _randomCodeGenerator.GenerateUniqueCode();
        mappedTeamAndEmployees.CreatedDate = DateTime.Now;
        mappedTeamAndEmployees.IsDeleted = false;

        var createdTeamAndEmployee = await _teamAndEmployeeService.Create(mappedTeamAndEmployees);

        var response = _mapper.Map<CreatedTeamAndEmployeesCommandResponse>(createdTeamAndEmployee);
        return response;
    }
}