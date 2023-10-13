using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Models;
using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.EmployeeService;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetListByInActive;

public class GetListByInActiveTeamAndEmployeesQuery : IRequestHandler<GetListByInActiveTeamAndEmployeesRequest, GetListResponse<GetListTeamAndEmployeeListItemDto>>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;
    private readonly IEmployeeService _employeeService;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;

    public GetListByInActiveTeamAndEmployeesQuery(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, ITeamService teamService, IEmployeeService employeeService, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamService = teamService;
        _employeeService = employeeService;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
    }

    public async Task<GetListResponse<GetListTeamAndEmployeeListItemDto>> Handle(GetListByInActiveTeamAndEmployeesRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamAndEmployeesShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<TeamAndEmployees> teamAndEmployeesList = await _teamAndEmployeeService.GetInActiveList(request.PageRequest.Page, size: request.PageRequest.PageSize);

        GetListResponse<GetListTeamAndEmployeeListItemDto> mappedTeamAndEmployeeListModel = _mapper.Map<GetListResponse<GetListTeamAndEmployeeListItemDto>>(teamAndEmployeesList);

        foreach (var item in mappedTeamAndEmployeeListModel.Items)
        {
            var team = await _teamService.GetById(item.TeamId);
            await _teamAndEmployeesBusinessRules.TeamIdShouldBeExists(item.TeamId);

            var employee = await _employeeService.GetById(item.EmployeeId);
            await _teamAndEmployeesBusinessRules.EmployeeIdShouldBeExists(item.EmployeeId);

            //item.TeamId = team.Id;
            //item.EmployeeId = employee.Id;
        }

        return mappedTeamAndEmployeeListModel;

        throw new NotImplementedException();
    }
}
