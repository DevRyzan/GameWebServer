using Application.Features.SupportRequestFeatures.SupportRequestCategories.Models;
using Core.Application.Caching;
using Core.Application.Requests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetList;
public class GetListSupportRequestCategoryQueryRequest : IRequest<SupportRequestCategoryListModel>, ICachableRequest //, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => new[] { Admin, SupportRequestCategoryGetList };

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListSupportRequestCategoryQueryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAndTags";
}

