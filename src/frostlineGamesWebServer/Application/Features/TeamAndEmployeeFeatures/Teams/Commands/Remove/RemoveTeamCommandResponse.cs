using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Remove;

public class RemoveTeamCommandResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}