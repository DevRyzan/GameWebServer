using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Application.Caching;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByCategoryId;

public class GetListByCategoryIdSuppRequestAndCategoryRequest : IRequest<GetListResponse<GetListByCategoryIdSuppRequestAndCategoryResponse>>, ICachableRequest
{
    public GetByCategoryIdSupportRequestAndCategoryDto GetByCategoryIdSupportRequestAndCategoryDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByCategoryIdSuppRequestAndCategoryRequest ({GetByCategoryIdSupportRequestAndCategoryDto.Id},{GetByCategoryIdSupportRequestAndCategoryDto.PageRequest.Page},{GetByCategoryIdSupportRequestAndCategoryDto.PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
