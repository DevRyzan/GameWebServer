using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;
using Core.Application.Caching;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetById;


public class GetByIdSupportRequestCategoryQueryRequest : IRequest<SupportRequestCategoryDto>, ICachableRequest
{
    public GetByIdSupportRequestCategoryDto GetByIdSupportRequestCategoryDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdSupportRequestCategoryQueryRequest ({GetByIdSupportRequestCategoryDto.Id}) ";
    public string? CacheGroupKey => "SupportRequestAndTags";
}
