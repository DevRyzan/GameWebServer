using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByInActive;

public class GetListByInActiveSuppRequestAndCategoryRequest : IRequest<GetListResponse<GetListByInActiveSuppRequestAndCategoryResponse>>, ICachableRequest // , ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    //public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryGetList };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByInActiveSuppRequestAndCategoryRequest ({PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
