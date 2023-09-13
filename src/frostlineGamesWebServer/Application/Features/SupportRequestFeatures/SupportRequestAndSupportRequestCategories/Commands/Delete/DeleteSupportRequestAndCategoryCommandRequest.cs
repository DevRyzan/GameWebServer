using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Delete;

public class DeleteSupportRequestAndCategoryCommandRequest : IRequest<DeleteSupportRequestAndCategoryCommandResponse>, ITransactionalRequest, ICacheRemoverRequest //,ISecuredRequest
{
    public int Id { get; set; }
    //public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryDelete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
