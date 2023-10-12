using Application.Feature.TeamFeatures.Employees.Constants;
using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities.Employees;

namespace Application.Feature.TeamFeatures.Employees.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;


    public EmployeeBusinessRules(IEmployeeRepository employeeRepository, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _employeeRepository = employeeRepository;
        _userRepository = userRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task EmployeeIdShouldBeExist(Guid id)
    {
        Employee? employee = await _employeeRepository.GetAsync(a => a.Id.Equals(id));
        if (employee == null) throw new BusinessException(EmployeeMessages.EmployeeDoesNotExist);
    }
    public async Task UserShouldBeExist(Guid userId)
    {
        User? user = await _userRepository.GetAsync(a => a.Id.Equals(userId));
        if (user is null) throw new BusinessException(EmployeeMessages.UserShouldNotBeExist);
    }
    public async Task UserShouldBeStaffOrAdmin(Guid userId)
    {
        var userAndOperation = await _userOperationClaimRepository.GetAsync(a => a.UserId.Equals(userId));
        if (userAndOperation is null) throw new BusinessException(EmployeeMessages.UserShouldBeStaffOrAdmin);
    }

    public async Task UserShouldNotBeExistInEmployeeTable(Guid userId)
    {
        Employee? employee = await _employeeRepository.GetAsync(a => a.UserId.Equals(userId));
        if (employee != null) throw new BusinessException(EmployeeMessages.UserShouldNotBeExistInEmployeeTable);
    }
    public virtual async Task EmployeeShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(EmployeeMessages.PageRequestDontSuccess);
    }
}
