using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
{
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public DeleteEmployeeCommandHandler(EmployeeBusinessRules employeeBusinessRules, IMapper mapper, IEmployeeService employeeService)
    {
        _employeeBusinessRules = employeeBusinessRules;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.EmployeeIdShouldBeExist(request.Id);
        Employee employee = await _employeeService.GetById(request.Id);

        employee.Status = false;
        await _employeeService.Delete(employee);

        DeleteEmployeeCommandResponse mappedResponse = _mapper.Map<DeleteEmployeeCommandResponse>(employee);

        return mappedResponse;
    }
}
