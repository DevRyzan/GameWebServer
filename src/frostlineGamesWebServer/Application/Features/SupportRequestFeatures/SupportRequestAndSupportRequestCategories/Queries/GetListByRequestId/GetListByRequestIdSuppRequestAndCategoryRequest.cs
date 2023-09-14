using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Application.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;

public class GetListByRequestIdSuppRequestAndCategoryRequest : IRequest<GetListResponse<GetListByRequestIdSuppRequestAndCategoryResponse>>, ICachableRequest
{
    public GetByRequestIdSupportRequestAndCategoryDto GetByRequestIdSupportRequestAndCategoryDto { get; set; }
    public PageRequest PageRequest { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByRequestIdSuppRequestAndCategoryRequest ({GetByRequestIdSupportRequestAndCategoryDto.RequestId},{PageRequest.Page},{PageRequest.PageSize}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";

}
