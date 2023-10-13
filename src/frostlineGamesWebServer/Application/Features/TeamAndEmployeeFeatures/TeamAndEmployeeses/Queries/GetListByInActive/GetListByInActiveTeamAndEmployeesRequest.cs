using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Models;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetListByInActive;

public class GetListByInActiveTeamAndEmployeesRequest : IRequest<GetListResponse<GetListTeamAndEmployeeListItemDto>>//, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, TeamAndEmployeeGetById };



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListByInActiveTeamAndEmployeesRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeamAndEmployeeses";
}
