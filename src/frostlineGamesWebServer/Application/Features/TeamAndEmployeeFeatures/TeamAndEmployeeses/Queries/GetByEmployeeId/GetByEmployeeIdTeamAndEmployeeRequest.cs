using Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Dtos;
using MediatR;

namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Queries.GetByEmployeeId;

public class GetByEmployeeIdTeamAndEmployeeRequest : IRequest<GetByEmployeeIdTeamAndEmployeeResponse>//, ICachableRequest
{
    public GetByEmployeeIdTeamAndEmployeeDto GetByEmployeeIdTeamAndEmployeeDto { get; set; }




    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByEmployeeIdTeamAndEmployeeRequest ({GetByEmployeeIdTeamAndEmployeeDto.EmployeeId}) ";
    //public string? CacheGroupKey => "GetTeamAndEmployeeses";
}