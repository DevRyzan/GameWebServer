using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;

public class DeleteEmployeeCommandResponse : IDto
{
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}
