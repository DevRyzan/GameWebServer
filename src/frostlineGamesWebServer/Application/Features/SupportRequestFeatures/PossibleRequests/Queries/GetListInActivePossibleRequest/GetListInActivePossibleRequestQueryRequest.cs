using Application.Features.SupportRequestFeatures.PossibleRequests.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListInActivePossibleRequest;

public class GetListInActivePossibleRequestQueryRequest : IRequest<PossibleRequestListModel>, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListInActivePossibleRequestQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequests";
}
