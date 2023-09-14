using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestAndTags.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Delete;
public class DeleteSupportRequestAndTagCommandRequest : IRequest<DeleteSupportRequestAndTagCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, SupportRequestAndTagRemove };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAnTags";
}
