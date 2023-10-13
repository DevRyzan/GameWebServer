using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;

public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQueryRequest, GetByIdTeamQueryResponse>
{
    private readonly ITeamService _teamservice;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetByIdTeamQueryHandler(ITeamService teamservice, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamservice = teamservice;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<GetByIdTeamQueryResponse> Handle(GetByIdTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.TeamIdShouldBeExist(request.GetByIdTeamDto.Id);

        Team team = await _teamservice.GetById(request.GetByIdTeamDto.Id);

        GetByIdTeamQueryResponse mappedResponse = _mapper.Map<GetByIdTeamQueryResponse>(team);

        return mappedResponse;
    }
}