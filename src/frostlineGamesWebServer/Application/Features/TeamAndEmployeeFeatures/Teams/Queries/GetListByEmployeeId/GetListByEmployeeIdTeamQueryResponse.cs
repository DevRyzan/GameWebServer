using Core.Application.Dtos;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListByEmployeeId;


public class GetListByEmployeeIdTeamQueryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}