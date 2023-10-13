using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByName;

public class GetByNameTeamQueryHandler : IRequestHandler<GetByNameTeamQueryRequest, GetByNameTeamQueryResponse>
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetByNameTeamQueryHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<GetByNameTeamQueryResponse> Handle(GetByNameTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamNameShouldBeExist(request.GetByNameTeamDto.Name);

        Team team = await _teamService.GetByName(request.GetByNameTeamDto.Name);

        GetByNameTeamQueryResponse mappedResponse = _mapper.Map<GetByNameTeamQueryResponse>(team);
        return mappedResponse;
    }
}
