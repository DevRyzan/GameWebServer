using Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByName;

public class GetByNameTeamQueryRequest : IRequest<GetByNameTeamQueryResponse>//, ICachableRequest
{
    public GetByNameTeamDto GetByNameTeamDto { get; set; }



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByNameTeamQueryRequest ({GetByNameTeamDto.Name}) ";
    //public string? CacheGroupKey => "GetTeams";

}