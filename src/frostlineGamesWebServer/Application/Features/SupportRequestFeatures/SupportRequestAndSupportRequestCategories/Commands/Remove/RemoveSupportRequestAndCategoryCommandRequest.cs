using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestAndCategoryCommandRequest : IRequest<RemoveSupportRequestAndCategoryCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public RemovedSupportRequestAndSupportRequestCategoryDto RemovedSupportRequestAndSupportRequestCategoryDto { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryRemove };

    public bool BypassCache { get; }
    public string? CacheKey => $"RemoveSupportRequestAndCategoryCommandRequest ({RemovedSupportRequestAndSupportRequestCategoryDto.Id} ) ";
    public string CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
