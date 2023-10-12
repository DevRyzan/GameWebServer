using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;



namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;


public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
{
    private readonly IEmployeeService _employeeService;
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(EmployeeBusinessRules employeeBusinessRules, IMapper mapper, IEmployeeService employeeService)
    {
        _employeeBusinessRules = employeeBusinessRules;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.UserShouldBeExist(request.UserId);
        await _employeeBusinessRules.EmployeeIdShouldBeExist(request.Id);
        Employee employee = await _employeeService.GetById(request.Id);

        employee.UserId = request.UserId;

        await _employeeService.Update(employee);

        UpdateEmployeeCommandResponse mappedResponse = _mapper.Map<UpdateEmployeeCommandResponse>(employee);

        return mappedResponse;
    }
}
