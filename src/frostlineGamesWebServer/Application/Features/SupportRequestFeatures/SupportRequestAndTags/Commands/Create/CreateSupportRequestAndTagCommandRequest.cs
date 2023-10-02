using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;
using Core.Application.Caching;
using Core.Application.Transaction;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Create;

public class CreateSupportRequestAndTagCommandRequest : IRequest<CreateSupportRequestAndTagCommandResponse>, ITransactionalRequest, ICacheRemoverRequest//ISecuredRequest
{

    public CreatedSupportRequestAndTagDto CreatedSupportRequestAndTagDto { get; set; }
 
    
    //public string[] Roles => new[] { Admin, SupportRequestAndTagAdd };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSupportRequestAnTags";
}
