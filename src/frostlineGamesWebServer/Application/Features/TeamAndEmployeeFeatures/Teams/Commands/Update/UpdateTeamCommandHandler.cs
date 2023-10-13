using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Update;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommandRequest, UpdateTeamCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamBusinessRule _teamBusinessRule;

    public UpdateTeamCommandHandler(IMapper mapper, ITeamService teamService, TeamBusinessRule teamBusinessRule)
    {
        _mapper = mapper;
        _teamService = teamService;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<UpdateTeamCommandResponse> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamIdShouldBeExist(request.Id);
        await _teamBusinessRule.TeamNameAlreadyShouldBeExist(request.Name);

        Team team = await _teamService.GetById(request.Id);

        team.Name = request.Name;
        team.Status = request.Status;
        team.UpdatedDate = DateTime.UtcNow;

        await _teamService.Update(team);

        UpdateTeamCommandResponse updateTeamCommandResponse = _mapper.Map<UpdateTeamCommandResponse>(team);

        return updateTeamCommandResponse;
    }
}