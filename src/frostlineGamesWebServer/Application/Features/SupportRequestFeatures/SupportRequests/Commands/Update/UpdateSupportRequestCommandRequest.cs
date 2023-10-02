using Application.Features.SupportRequestFeatures.SupportRequestComments.Dtos;
using Core.Application.Caching;
using Core.Application.Transaction;
using Domain.Enums;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Update;

public class UpdateSupportRequestCommandRequest : IRequest<UpdateSupportRequestCommandResponse>, ITransactionalRequest, ICacheRemoverRequest //ISecuredRequest, 
{
    public int Id { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"UpdateSupportRequestCommandRequest ({Id} ) ";
    public string? CacheGroupKey => "GetSupportRequest";
}
