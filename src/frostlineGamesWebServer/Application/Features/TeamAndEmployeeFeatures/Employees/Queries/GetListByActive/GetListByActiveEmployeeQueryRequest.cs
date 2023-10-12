using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Queries.GetListByActive;

public class GetListByActiveEmployeeQueryRequest : IRequest<GetListResponse<GetListByActiveEmployeeQueryResponse>>//, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, EmployeeGetList };



    //public bool BypassCache { get; }
    //public TimeSpan? SlidingExpiration { get; }
    //public string CacheKey => $"GetListByActiveEmployeeQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    //public string? CacheGroupKey => "GetEmployees";

}
