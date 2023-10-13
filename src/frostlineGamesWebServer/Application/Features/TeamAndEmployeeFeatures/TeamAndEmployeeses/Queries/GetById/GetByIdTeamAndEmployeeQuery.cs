using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetById;

public class GetByIdTeamAndEmployeeQuery : IRequestHandler<GetByIdTeamAndEmployeeQueryRequest, GetByIdTeamAndEmployeeQueryResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public GetByIdTeamAndEmployeeQuery(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, ITeamService teamService, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamService = teamService;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<GetByIdTeamAndEmployeeQueryResponse> Handle(GetByIdTeamAndEmployeeQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamAndEmployeesIdShouldBeExist(request.GetByIdTeamAndEmployeeDto.Id);
        TeamAndEmployees teamAndEmployees = await _teamAndEmployeeService.GetById(request.GetByIdTeamAndEmployeeDto.Id);

        GetByIdTeamAndEmployeeQueryResponse mappedResponse = _mapper.Map<GetByIdTeamAndEmployeeQueryResponse>(teamAndEmployees);

        return mappedResponse;

    }
}
