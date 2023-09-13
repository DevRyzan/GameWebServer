using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListInActive;

public class GetListInActivePossibleRequestAndTagQueryRequest : IRequest<PossibleRequestAndTagListModel>, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestAndTagGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListInActivePossibleRequestAndTagQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";

}
