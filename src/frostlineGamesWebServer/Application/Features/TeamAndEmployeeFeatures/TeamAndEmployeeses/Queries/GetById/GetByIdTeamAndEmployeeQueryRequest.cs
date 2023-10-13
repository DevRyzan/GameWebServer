using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetById;

public class GetByIdTeamAndEmployeeQueryRequest : IRequest<GetByIdTeamAndEmployeeQueryResponse>//, ICachableRequest
{
    public GetByIdTeamAndEmployeeDto GetByIdTeamAndEmployeeDto { get; set; }


    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByIdTeamAndEmployeeQueryRequest ({GetByIdTeamAndEmployeeDto.Id}) ";
    //public string? CacheGroupKey => "GetTeamAndEmployeeses";
}
