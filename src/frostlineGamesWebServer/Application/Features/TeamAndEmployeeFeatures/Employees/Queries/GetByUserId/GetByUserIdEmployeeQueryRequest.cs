using Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos;
using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.TeamFeatures.Employees.Queries.GetByUserId
{
    public class GetByUserIdEmployeeQueryRequest : IRequest<GetByUserIdEmployeeQueryResponse>//, ICachableRequest
    {
        public GetByUserIdEmployeeDto GetByUserIdEmployeeDto { get; set; }


        //public bool BypassCache { get; }
        //public TimeSpan? SlidingExpiration { get; }
        //public string CacheKey => $"GetByUserIdEmployeeQueryRequest ({GetByUserIdEmployeeDto.UserId},{GetByUserIdEmployeeDto.PageRequest.Page},{GetByUserIdEmployeeDto.PageRequest.PageSize}) ";
        //public string? CacheGroupKey => "GetEmployees";
    }
}
