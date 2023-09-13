using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Constants.OperationClaims;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestAndCategoryCommandRequest : IRequest<RemoveSupportRequestAndCategoryCommandResponse>, ISecuredRequest, ITransactionalRequest,ICacheRemoverRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryRemove };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
