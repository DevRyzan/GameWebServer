using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Delete;

public class DeleteTeamAndEmployeesCommandHandler : IRequestHandler<DeleteTeamAndEmployeesCommandRequest, DeleteTeamAndEmployeesCommandResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public DeleteTeamAndEmployeesCommandHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, ITeamService teamService, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamService = teamService;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<DeleteTeamAndEmployeesCommandResponse> Handle(DeleteTeamAndEmployeesCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamAndEmployeesIdShouldBeExist(request.Id);
        var teamAndEmployees = await _teamAndEmployeeService.GetById(request.Id);

        teamAndEmployees.Status = false;
        teamAndEmployees.DeletedDate = DateTime.UtcNow;


        var deletedTeamAndEmployees = await _teamAndEmployeeService.Delete(teamAndEmployees);

        DeleteTeamAndEmployeesCommandResponse mappedResponse = _mapper.Map<DeleteTeamAndEmployeesCommandResponse>(deletedTeamAndEmployees);

        return mappedResponse;

    }
}
