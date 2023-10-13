using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Rules;
using Application.Services.EmployeeService;
using Application.Services.Repositories.FileRepositories;
using Application.Services.TeamAndEmployeeService;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;

public class GetByTeamIdTeamAndEmployeeQueryHandler : IRequestHandler<GetByTeamIdTeamAndEmployeeQueryRequest, GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse>>
{
    private readonly ITeamAndEmployeeService _teamAndEmployeeService;
    private readonly IMapper _mapper;
    private readonly TeamAndEmployeesBusinessRules _teamAndEmployeesBusinessRules;
    private readonly IEmployeeService _employeeService;
    private readonly IUserService _userService;
    private readonly IUserDetailService _userDetailService;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;

    public GetByTeamIdTeamAndEmployeeQueryHandler(ITeamAndEmployeeService teamAndEmployeeService, IMapper mapper, TeamAndEmployeesBusinessRules teamAndEmployeesBusinessRules, IEmployeeService employeeService, IUserDetailImageFileRepository userDetailImageFileRepository, IUserDetailService userDetailService, IUserService userService)
    {
        _teamAndEmployeeService = teamAndEmployeeService;
        _mapper = mapper;
        _teamAndEmployeesBusinessRules = teamAndEmployeesBusinessRules;
        _employeeService = employeeService;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userDetailService = userDetailService;
        _userService = userService;
    }

    public async Task<GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse>> Handle(GetByTeamIdTeamAndEmployeeQueryRequest request, CancellationToken cancellationToken)
    {
        await _teamAndEmployeesBusinessRules.TeamIdShouldBeExists(request.GetByTeamIdTeamAndEmployeeDto.TeamId);

        IPaginate<TeamAndEmployees> teamAndEmployees = await _teamAndEmployeeService.GetByTeamIdList(request.GetByTeamIdTeamAndEmployeeDto.TeamId, index: request.GetByTeamIdTeamAndEmployeeDto.PageRequest.Page, size: request.GetByTeamIdTeamAndEmployeeDto.PageRequest.PageSize);

        var employeeList = await _employeeService.GetListByIds(teamAndEmployees.Items.Select(x => x.EmployeeId).ToList());
        var userList = await _userService.GetListByUserIds(employeeList.Select(x => x.UserId).ToList());
        var userDetailList = await _userDetailService.GetListByUserIds(userList.Select(x => x.Id).ToList());

        var mappedResponse = _mapper.Map<GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse>>(teamAndEmployees);

        for (int i = 0; i < mappedResponse.Items.Count; i++)
        {
            mappedResponse.Items[i].EmployeeName = userList[i].FirstName + " " + userList[i].LastName;
            mappedResponse.Items[i].IsOnline = userDetailList[i].IsOnline.Value;
            mappedResponse.Items[i].UserDetailId = userDetailList[i].Id;
        }

        foreach (var item in mappedResponse.Items)
        {
            var userImageFile = await _userDetailImageFileRepository.GetAsync(x => x.UserDetail.Id.Equals(item.UserDetailId));

            if (userImageFile != null)
            {
                item.ImagePath = userImageFile.Path.Replace('\\', '/');
            }
            else
            {
                item.ImagePath = "user-images/defaultimage.png";
            }
        }

        return mappedResponse;
    }
}
