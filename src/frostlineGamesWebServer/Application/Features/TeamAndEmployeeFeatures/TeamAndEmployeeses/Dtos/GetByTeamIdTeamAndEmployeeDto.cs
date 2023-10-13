using Core.Application.Requests;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;

public class GetByTeamIdTeamAndEmployeeDto
{
    public int TeamId { get; set; }
    public PageRequest PageRequest { get; set; }
}