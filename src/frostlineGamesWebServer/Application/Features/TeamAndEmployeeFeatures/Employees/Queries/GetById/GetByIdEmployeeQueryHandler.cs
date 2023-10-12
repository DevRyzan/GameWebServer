using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using Application.Services.Repositories.FileRepositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities.Employees;
using Domain.Entities.Files;
using Domain.Entities.Users;
using MediatR;
using static System.Net.Mime.MediaTypeNames;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;



namespace Application.Feature.TeamFeatures.Employees.Queries.GetById;

public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IUserDetailService _userDetailService;
    private readonly IUserDetailImageFileRepository _userDetailImageFileRepository;
    private readonly IUserService _userService;

    public GetByIdEmployeeQueryHandler(IEmployeeService employeeService, IMapper mapper, EmployeeBusinessRules employeeBusinessRules, IUserDetailService userDetailService, IUserDetailImageFileRepository userDetailImageFileRepository, IUserService userService)
    {
        _employeeService = employeeService;
        _mapper = mapper;
        _employeeBusinessRules = employeeBusinessRules;
        _userDetailService = userDetailService;
        _userDetailImageFileRepository = userDetailImageFileRepository;
        _userService = userService;
    }

    public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.EmployeeIdShouldBeExist(request.GetByIdEmployeeDto.Id);

        Employee employee = await _employeeService.GetById(request.GetByIdEmployeeDto.Id);
        User user = await _userService.GetById(employee.UserId);
        UserDetail userDetail = await _userDetailService.GetByUserId(employee.UserId);
        UserDetailImageFile userDetailImageFile = await _userDetailImageFileRepository.GetAsync(x => x.Id.Equals(userDetail.Id));


        GetByIdEmployeeQueryResponse mappedResponse = _mapper.Map<GetByIdEmployeeQueryResponse>(employee);

        mappedResponse.UserName = user.FirstName + " " + user.LastName;
        mappedResponse.UserImagePath = userDetailImageFile != null ? userDetailImageFile.Path.Replace('\\', '/') : "user-images/defaultimage.png";

        return mappedResponse;
    }
}
