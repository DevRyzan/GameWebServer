using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;

public class GetByIdTeamQueryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
