using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Create;

public class CreateTeamCommandResponse : IDto
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }

}