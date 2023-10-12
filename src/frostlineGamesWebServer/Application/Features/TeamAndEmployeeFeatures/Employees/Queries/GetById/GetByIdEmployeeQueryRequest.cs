using Application.Feature.TeamAndEmployeeFeatures.Employees.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Feature.TeamFeatures.Employees.Queries.GetById
{
    public class GetByIdEmployeeQueryRequest : IRequest<GetByIdEmployeeQueryResponse>//, ICachableRequest
    {
        public GetByIdEmployeeDto GetByIdEmployeeDto { get; set; }



        //public bool BypassCache { get; }
        //public TimeSpan? SlidingExpiration { get; }
        //public string CacheKey => $"GetByIdEmployeeQueryRequest ({GetByIdEmployeeDto.Id}) ";
        //public string? CacheGroupKey => "GetEmployees";

    }
}
