using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListByEmployeeId;

public class GetListByEmployeeIdTeamQueryHandler : IRequestHandler<GetListByEmployeeIdTeamQueryRequest, IEnumerable<GetListByEmployeeIdTeamQueryResponse>>
{
    private readonly ITeamService _teamService;
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetListByEmployeeIdTeamQueryHandler(ITeamService teamService, IMapper mapper, TeamBusinessRule teamBusinessRule, ITeamAndEmployeeService teamAndEmployeeService)
    {
        _teamService = teamService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
        _teamAndEmployeeService = teamAndEmployeeService;
    }

    public async Task<IEnumerable<GetListByEmployeeIdTeamQueryResponse>> Handle(GetListByEmployeeIdTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.EmployeeShouldBeExistInTeamAndEmployeeTable(request.GetByEmployeeIdTeamDto.EmployeeId);

        IEnumerable<TeamAndEmployees> teamAndEmployee = await _teamAndEmployeeService.GetListByEmployeeId(request.GetByEmployeeIdTeamDto.EmployeeId);

        IEnumerable<Team> teamList = await _teamService.GetListByTeamId(teamAndEmployee.Select(x => x.TeamId).ToList());

        IEnumerable<GetListByEmployeeIdTeamQueryResponse> mappedResponse = _mapper.Map<IEnumerable<GetListByEmployeeIdTeamQueryResponse>>(teamList);

        return mappedResponse;

    }
}