using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using Application.Services.UserServices.UserService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreatedEmployeeCommandResponse>
{
    private readonly IEmployeeService _employeeService;
    private readonly IUserService _userService;
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IMapper _mapper;
    private readonly IRandomCodeGenerator _randomCodeGenerator;
    public CreateEmployeeCommandHandler(IEmployeeService employeeService, IUserService userService, EmployeeBusinessRules employeeBusinessRules, IMapper mapper, IRandomCodeGenerator randomCodeGenerator)
    {
        _employeeService = employeeService;
        _userService = userService;
        _employeeBusinessRules = employeeBusinessRules;
        _mapper = mapper;
        _randomCodeGenerator = randomCodeGenerator;
    }

    public async Task<CreatedEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.UserShouldBeExist(userId: request.UserId);

        await _employeeBusinessRules.UserShouldBeStaffOrAdmin(userId: request.UserId);

        var createEmployee = _mapper.Map<Employee>(request);

        var user = await _userService.GetById(id: createEmployee.UserId);

        createEmployee.Code = _randomCodeGenerator.GenerateUniqueCode();
        createEmployee.Status = true;
        createEmployee.CreatedDate = DateTime.Now;
        createEmployee.IsDeleted = false;

        var createdEmployee = await _employeeService.Create(createEmployee);

        var mappedEmployee = _mapper.Map<CreatedEmployeeCommandResponse>(createdEmployee);

        mappedEmployee.FirstName = user.FirstName;
        mappedEmployee.LastName = user.LastName;
        mappedEmployee.Email = user.Email;

        return mappedEmployee;
    }
}