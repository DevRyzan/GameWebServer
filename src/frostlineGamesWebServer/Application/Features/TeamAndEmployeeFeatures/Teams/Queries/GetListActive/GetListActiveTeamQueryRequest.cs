using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListActive;

public class GetListActiveTeamQueryRequest : IRequest<GetListResponse<GetListActiveQueryTeamResponse>>//, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, TeamGet };



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListActiveTeamQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeams";

}
