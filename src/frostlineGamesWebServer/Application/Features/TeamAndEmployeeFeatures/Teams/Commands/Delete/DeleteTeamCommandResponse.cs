using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;

public class DeleteTeamCommandResponse : IDto
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}