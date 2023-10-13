using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.ChangeStatus;

public class ChangeStatusTeamAndEmployeeCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}