using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListInActive;

public class GetListInActiveTeamQueryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}