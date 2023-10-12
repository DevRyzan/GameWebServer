using Application.Feature.TeamFeatures.Employees.Rules;
using Application.Services.EmployeeService;
using AutoMapper;
using Domain.Entities.Employees;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;

public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommandRequest, RemoveEmployeeCommandResponse>
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _employeeBusinessRules;

    public RemoveEmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
    {
        _employeeService = employeeService;
        _mapper = mapper;
        _employeeBusinessRules = employeeBusinessRules;
    }

    public async Task<RemoveEmployeeCommandResponse> Handle(RemoveEmployeeCommandRequest request, CancellationToken cancellationToken)
    {
        await _employeeBusinessRules.EmployeeIdShouldBeExist(request.Id);

        Employee employee = await _employeeService.GetById(request.Id);

        Employee deletedEmployee = await _employeeService.Remove(employee);

        RemoveEmployeeCommandResponse removedItemResponse = _mapper.Map<RemoveEmployeeCommandResponse>(deletedEmployee);

        return removedItemResponse;

    }
}
