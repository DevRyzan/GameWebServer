using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Remove;

public class RemoveTeamCommandHandler : IRequestHandler<RemoveTeamCommandRequest, RemoveTeamCommandResponse>
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public RemoveTeamCommandHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<RemoveTeamCommandResponse> Handle(RemoveTeamCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamIdShouldBeExist(request.Id);

        Team team = await _teamService.GetById(request.Id);
        await _teamService.Remove(team);

        RemoveTeamCommandResponse mappedResponse = _mapper.Map<RemoveTeamCommandResponse>(team);

        return mappedResponse;
    }
}