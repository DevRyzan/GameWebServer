using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Core.Application.Caching;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Queries.GetById;

public class GetByIdSuppRequestCommentRequest : IRequest<GetByIdSuppRequestCommentResponse>, ICachableRequest
{
    public GetByIdSupportRequestCommentDto GetByIdSupportRequestCommentDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetListByRequestIdRequestCommentRequest ({GetByIdSupportRequestCommentDto.Id} ) ";
    public string? CacheGroupKey => "GetSupportRequestComments";

}
