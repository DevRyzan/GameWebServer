using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetById;

public class GetByIdSuppRequestAndCategoryRequest : IRequest<GetByIdSuppRequestAndCategoryResponse>, ICachableRequest
{
    public GetByIdSupportRequestAndCategoryDto GetByIdSupportRequestAndCategoryDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdSuppRequestAndCategoryRequest ({GetByIdSupportRequestAndCategoryDto.Id}) ";
    public string? CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
