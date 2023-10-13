using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.ChangeStatus;

public class ChangeStatusTeamCommandHandler : IRequestHandler<ChangeStatusTeamCommandRequest, ChangeStatusTeamCommandResponse>
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public ChangeStatusTeamCommandHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<ChangeStatusTeamCommandResponse> Handle(ChangeStatusTeamCommandRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamIdShouldBeExist(request.Id);
        Team team = await _teamService.GetById(request.Id);
        team.Status = team.Status == true ? false : true;
        team.UpdatedDate = DateTime.Now;
        Team changedStatus = await _teamService.Update(team);

        ChangeStatusTeamCommandResponse mappedResponse = _mapper.Map<ChangeStatusTeamCommandResponse>(changedStatus);
        return mappedResponse;
    }
}