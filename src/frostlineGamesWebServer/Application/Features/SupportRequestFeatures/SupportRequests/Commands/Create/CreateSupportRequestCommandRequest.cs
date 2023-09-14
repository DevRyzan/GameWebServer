using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;
using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Create;

public class CreateSupportRequestCommandRequest : IRequest<CreateSupportRequestCommandResponse>, ITransactionalRequest, ICacheRemoverRequest
{
    public Guid UserId { get; set; }
    public string? UserIP { get; set; }
    public CreatedSupportRequestDto CreatedSupportRequestDto { get; set; }


    public bool BypassCache { get; }
    public string CacheKey { get; }
    public string? CacheGroupKey => "GetSupportRequest";
}
