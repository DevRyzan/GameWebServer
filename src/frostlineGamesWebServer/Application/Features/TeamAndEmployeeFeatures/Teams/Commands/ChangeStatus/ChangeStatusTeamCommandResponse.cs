using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.ChangeStatus;

public class ChangeStatusTeamCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
