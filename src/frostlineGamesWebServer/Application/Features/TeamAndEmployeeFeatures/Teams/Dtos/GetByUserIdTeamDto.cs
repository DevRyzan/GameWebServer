using Core.Application.Requests;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;

public class GetByUserIdTeamDto
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
