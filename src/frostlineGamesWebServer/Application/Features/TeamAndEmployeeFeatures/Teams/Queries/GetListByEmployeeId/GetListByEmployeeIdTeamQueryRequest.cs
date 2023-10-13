using Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListByEmployeeId;

public class GetListByEmployeeIdTeamQueryRequest : IRequest<IEnumerable<GetListByEmployeeIdTeamQueryResponse>>//, ICachableRequest
{
    public GetByEmployeeIdTeamDto GetByEmployeeIdTeamDto { get; set; }


    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListByEmployeeIdTeamQueryRequest ({GetByEmployeeIdTeamDto.EmployeeId},{GetByEmployeeIdTeamDto.PageRequest.Page},{GetByEmployeeIdTeamDto.PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeams";

}