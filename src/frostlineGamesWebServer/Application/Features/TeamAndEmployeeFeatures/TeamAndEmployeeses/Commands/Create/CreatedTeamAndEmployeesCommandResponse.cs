using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;

public class CreatedTeamAndEmployeesCommandResponse : IDto
{
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }
}