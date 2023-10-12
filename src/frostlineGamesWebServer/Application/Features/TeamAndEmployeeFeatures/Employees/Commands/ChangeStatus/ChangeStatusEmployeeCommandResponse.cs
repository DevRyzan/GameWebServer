using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.ChangeStatus;

public class ChangeStatusEmployeeCommandResponse : IDto
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
}
