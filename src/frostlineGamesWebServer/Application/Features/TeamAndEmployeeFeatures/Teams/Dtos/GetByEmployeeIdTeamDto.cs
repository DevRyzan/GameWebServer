using Core.Application.Requests;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;

public class GetByEmployeeIdTeamDto
{
    public Guid EmployeeId { get; set; }
    public PageRequest PageRequest { get; set; }
}
