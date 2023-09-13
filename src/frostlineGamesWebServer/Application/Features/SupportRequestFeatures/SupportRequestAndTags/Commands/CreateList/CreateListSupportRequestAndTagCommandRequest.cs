using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestAndTags.Constants.OperationClaims;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.CreateList;

public class CreateListSupportRequestAndTagCommandRequest : IRequest<List<CreateListSupportRequestAndTagCommandResponse>>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int SupportRequestId { get; set; }
    public List<int> TagIds { get; set; }


    public string[] Roles => new[] { Admin, SupportRequestAndTagAdd };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAnTags";
}
