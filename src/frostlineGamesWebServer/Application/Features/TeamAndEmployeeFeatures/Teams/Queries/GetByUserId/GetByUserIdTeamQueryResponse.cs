using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByUserId;

public class GetByUserIdTeamQueryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
