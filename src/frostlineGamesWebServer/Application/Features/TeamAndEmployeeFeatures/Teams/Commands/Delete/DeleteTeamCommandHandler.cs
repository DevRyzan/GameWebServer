using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommandRequest, DeleteTeamCommandResponse>
{

    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public DeleteTeamCommandHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<DeleteTeamCommandResponse> Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamIdShouldBeExist(request.Id);

        Team team = await _teamService.GetById(request.Id);
        await _teamBusinessRule.TeamNameShouldBeExist(team.Name);
        team.Status = false;

        await _teamService.Update(team);

        DeleteTeamCommandResponse deletedTeamCommandResponse = _mapper.Map<DeleteTeamCommandResponse>(team);
        return deletedTeamCommandResponse;
    }
}
