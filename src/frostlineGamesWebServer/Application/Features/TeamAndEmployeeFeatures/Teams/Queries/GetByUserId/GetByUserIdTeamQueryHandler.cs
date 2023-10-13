using Application.Features.TeamAndEmployeeFeatures.Teams.Rules;
using Application.Services.EmployeeService;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByUserId;

public class GetByUserIdTeamQueryHandler : IRequestHandler<GetByUserIdTeamQueryRequest, IEnumerable<GetByUserIdTeamQueryResponse>>
{
    private readonly ITeamService _teamService;
    private readonly IEmployeeService _employeeService;
    private readonly IUserService _userService;
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly TeamBusinessRule _teamBusinessRule;

    public GetByUserIdTeamQueryHandler(ITeamService teamService, IEmployeeService employeeService, IUserService userService, ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, TeamBusinessRule teamBusinessRule)
    {
        _teamService = teamService;
        _employeeService = employeeService;
        _userService = userService;
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamBusinessRule = teamBusinessRule;
    }

    public async Task<IEnumerable<GetByUserIdTeamQueryResponse>> Handle(GetByUserIdTeamQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamBusinessRule.UserIdShouldBeExist(request.GetByUserIdTeamDto.UserId);
        User user = await _userService.GetById(request.GetByUserIdTeamDto.UserId);

        var employee = await _employeeService.GetByUserId(request.GetByUserIdTeamDto.UserId);

        await _teamBusinessRule.UserIdShouldBeExistInEmployeeTable(request.GetByUserIdTeamDto.UserId);
        await _teamBusinessRule.EmployeeShouldBeExistInTeamAndEmployeeTable(employee.Id);

        IEnumerable<TeamAndEmployees> teamAndEmployee = await _teamAndEmployeeService.GetListByEmployeeId(employee.Id);

        IEnumerable<Team> teamList = await _teamService.GetByUserId(teamAndEmployee.Select(x => x.TeamId).ToList());

        IEnumerable<GetByUserIdTeamQueryResponse> mappedResponse = _mapper.Map<IEnumerable<GetByUserIdTeamQueryResponse>>(teamList);

        return mappedResponse;

    }
}
