using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;
using Core.Persistence.Paging;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByTeamId;

public class GetByTeamIdTeamAndEmployeeQueryRequest : IRequest<GetListResponse<GetByTeamIdTeamAndEmployeeQueryResponse>>//, ICachableRequest
{
    public GetByTeamIdTeamAndEmployeeDto GetByTeamIdTeamAndEmployeeDto { get; set; }



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByTeamIdTeamAndEmployeeQueryRequest ({GetByTeamIdTeamAndEmployeeDto.TeamId}) ";
    //public string? CacheGroupKey => "GetTeamAndEmployeeses";
}