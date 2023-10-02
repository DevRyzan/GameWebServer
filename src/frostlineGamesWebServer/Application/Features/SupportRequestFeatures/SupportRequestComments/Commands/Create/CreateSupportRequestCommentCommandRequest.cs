using Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Dtos;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Create;

public class CreateSupportRequestCommentCommandRequest : IRequest<CreatedSupportRequestCommentResponse>,ITransactionalRequest
{
    public CreateSupportRequestCommentDto CreateSupportRequestCommentDto { get; set; }
    public Guid UserId { get; set; }
    public string? UserIP { get; set; }

    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequestComments";


}

