using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestAndTags.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Update;
public class UpdateSupportRequestAndTagCommandRequest : IRequest<UpdateSupportRequestAndTagCommandResponse>, ISecuredRequest, ITransactionalRequest , ICacheRemoverRequest
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int TagId { get; set; }
    public string[] Roles => new[] { Admin, SupportRequestAndTagUpdate };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAnTags";
}
