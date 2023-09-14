using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Update;

public class UpdateSupportRequestAndCategoryCommandRequest : IRequest<UpdateSupportRequestAndCategoryCommandResponse>, ICacheRemoverRequest,ITransactionalRequest//, ISecuredRequest
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public int RequestId { get; set; }


    //public string[] Roles => new[] { Admin, SupportRequestAndSupportRequestCategoryUpdate };



    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAndSupportRequestCategories";
}
