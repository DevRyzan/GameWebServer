using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;

public class UpdateEmployeeCommandResponse : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}
