using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;

public class GetByRequestIdSuppRequestAndCategoryRequest : IRequest<GetByRequestIdSuppRequestAndCategoryResponse>, ICachableRequest
{
    public GetByRequestIdSupportRequestAndCategoryDto GetByRequestIdSupportRequestAndCategoryDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByRequestIdSuppRequestAndCategoryRequest ({GetByRequestIdSupportRequestAndCategoryDto.RequestId}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";

}
