using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Remove;

public class RemoveTeamAndEmployeesCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }
}