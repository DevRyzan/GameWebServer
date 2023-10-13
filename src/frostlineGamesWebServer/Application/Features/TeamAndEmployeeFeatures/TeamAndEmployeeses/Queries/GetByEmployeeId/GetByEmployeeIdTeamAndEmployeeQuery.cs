using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.TeamAndEmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;

public class GetByEmployeeIdTeamAndEmployeeQuery : IRequestHandler<GetByEmployeeIdTeamAndEmployeeRequest, GetByEmployeeIdTeamAndEmployeeResponse>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public GetByEmployeeIdTeamAndEmployeeQuery(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<GetByEmployeeIdTeamAndEmployeeResponse> Handle(GetByEmployeeIdTeamAndEmployeeRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.EmployeeIdShouldBeExists(request.GetByEmployeeIdTeamAndEmployeeDto.EmployeeId);

        TeamAndEmployees teamAndEmployeeses = await _teamAndEmployeeService.GetByEmployeeId(request.GetByEmployeeIdTeamAndEmployeeDto.EmployeeId);

        GetByEmployeeIdTeamAndEmployeeResponse mappedResponse = _mapper.Map<GetByEmployeeIdTeamAndEmployeeResponse>(teamAndEmployeeses);

        return mappedResponse;
    }
}