using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;

public class RemoveEmployeeCommandResponse : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
