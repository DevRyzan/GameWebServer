using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;

public class EditCommentSupportRequestCommandRequest : IRequest<EditCommentSupportRequestCommandResponse>, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string Comment { get; set; }

    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";
}
