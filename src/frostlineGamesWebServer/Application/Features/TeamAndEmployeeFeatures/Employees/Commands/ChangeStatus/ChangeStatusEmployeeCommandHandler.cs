using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.ChangeStatus;

public class ChangeStatusEmployeeCommandHandler : IRequestHandler<ChangeStatusEmployeeCommandRequest, ChangeStatusEmployeeCommandResponse>
{
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public ChangeStatusEmployeeCommandHandler(EmployeeBusinessRules employeeBusinessRules, IMapper mapper, IEmployeeService employeeService)
    {
        _employeeBusinessRules = employeeBusinessRules;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public async Task<ChangeStatusEmployeeCommandResponse> Handle(ChangeStatusEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.EmployeeIdShouldBeExist(request.Id);
        Employee employee = await _employeeService.GetById(request.Id);

        employee.Status = employee.Status == true ? false : true;
        employee.UpdatedDate = DateTime.Now;

        Employee changedStatus = await _employeeService.Update(employee);

        ChangeStatusEmployeeCommandResponse mappedResponse = _mapper.Map<ChangeStatusEmployeeCommandResponse>(changedStatus);
        return mappedResponse;
    }
}