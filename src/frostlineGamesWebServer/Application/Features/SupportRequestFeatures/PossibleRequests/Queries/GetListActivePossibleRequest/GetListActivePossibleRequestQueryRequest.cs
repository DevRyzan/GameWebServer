using Application.Features.SupportRequestFeatures.PossibleRequests.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetListActivePossibleRequest;

public class GetListActivePossibleRequestQueryRequest : IRequest<PossibleRequestListModel>, ICachableRequest //, 
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListActivePossibleRequestQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequests";
}
