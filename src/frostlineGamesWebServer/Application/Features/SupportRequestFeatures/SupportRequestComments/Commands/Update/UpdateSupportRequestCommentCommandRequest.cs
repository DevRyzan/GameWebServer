using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;
public class UpdateSupportRequestCommentCommandRequest : IRequest<UpdatedSupportRequestCommentResponse>, ICacheRemoverRequest, ITransactionalRequest //ISecuredRequest, 
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public string Comment { get; set; }
    public int BardId { get; set; } // Request Açan admin Staff harici herkesin bard olması beklenmekte
    public Guid UserId { get; set; }//Admin yorum yapabilir admin username ihticayı var 
    public bool IsEdited { get; set; }
    public int SupportRequestId { get; set; }

    //public string[] Roles => new[] { Admin, SupportRequestCommentUpdate };


    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";
}
