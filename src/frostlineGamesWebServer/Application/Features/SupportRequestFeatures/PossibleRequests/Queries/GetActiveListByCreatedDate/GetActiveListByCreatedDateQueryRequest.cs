using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetActiveListByCreatedDate;

public class GetActiveListByCreatedDateQueryRequest : IRequest<IOrderedEnumerable<GetActiveListByCreatedDateQueryResponse>>, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestGet };



    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetActiveListByCreatedDateQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequests";

}

