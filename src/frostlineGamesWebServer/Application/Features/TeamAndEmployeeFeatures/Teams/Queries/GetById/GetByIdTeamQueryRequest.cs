using Application.Features.TeamAndEmployeeFeatures.Teams.Dtos;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Queries.GetById;

public class GetByIdTeamQueryRequest : IRequest<GetByIdTeamQueryResponse>//, ICachableRequest
{
    public GetByIdTeamDto GetByIdTeamDto { get; set; }





    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetByIdTeamQueryRequest ({GetByIdTeamDto.Id}) ";
    //public string? CacheGroupKey => "GetSubscriptions";
}