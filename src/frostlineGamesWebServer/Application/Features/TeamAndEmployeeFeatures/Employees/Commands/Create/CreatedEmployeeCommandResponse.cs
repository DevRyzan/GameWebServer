using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create;

public class CreatedEmployeeCommandResponse : IDto
{
    // Employee Create edilirken Teama atanması sonra mı yapılsın ? 
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
