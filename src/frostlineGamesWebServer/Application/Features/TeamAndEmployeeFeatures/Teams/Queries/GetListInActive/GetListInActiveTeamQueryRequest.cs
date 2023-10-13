using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetListInActive;

public class GetListInActiveTeamQueryRequest : IRequest<GetListResponse<GetListInActiveTeamQueryResponse>>//, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, TeamGet };


    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListInActiveTeamQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeams";

}