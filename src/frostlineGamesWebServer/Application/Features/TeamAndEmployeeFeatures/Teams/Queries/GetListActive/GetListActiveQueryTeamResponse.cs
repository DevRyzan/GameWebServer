using Core.Application.Dtos;



namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListActive;

public class GetListActiveQueryTeamResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }

}