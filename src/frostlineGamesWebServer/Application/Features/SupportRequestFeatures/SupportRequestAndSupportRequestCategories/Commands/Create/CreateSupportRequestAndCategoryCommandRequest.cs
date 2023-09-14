using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Constants.OperationClaims;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;
public class CreateSupportRequestAndCategoryCommandRequest : IRequest<CreateSupportRequestAndCategoryCommandResponse>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int SupportRequestId { get; set; }
    public int SupportRequestCategoryId { get; set; }


    public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryAdd };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}

