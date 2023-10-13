using Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetByUserId;

public class GetByUserIdTeamQueryRequest : IRequest<IEnumerable<GetByUserIdTeamQueryResponse>>//, ICachableRequest
{
    public GetByUserIdTeamDto GetByUserIdTeamDto { get; set; }



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByUserIdTeamQueryRequest ({GetByUserIdTeamDto.UserId},{GetByUserIdTeamDto.PageRequest.Page},{GetByUserIdTeamDto.PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeams";

}
