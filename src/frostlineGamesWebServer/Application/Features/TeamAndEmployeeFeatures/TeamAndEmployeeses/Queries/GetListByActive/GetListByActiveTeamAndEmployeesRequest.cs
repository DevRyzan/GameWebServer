using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Models;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetListByActive;

public class GetListByActiveTeamAndEmployeesRequest : IRequest<GetListResponse<GetListTeamAndEmployeeListItemDto>>//, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, TeamAndEmployeeGetById };


    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListByActiveTeamAndEmployeesRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetTeamAndEmployeeses";

}
