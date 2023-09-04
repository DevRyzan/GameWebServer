using Core.Application.Pipelines.Authorization;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using Core.Application.Caching;
using Application.Feature.UserFeatures.Users.Dtos;
using Core.Application.Transaction;

namespace Application.Feature.UserFeatures.Users.Command.Create;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>, ISecuredRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public CreateUserDto CreateUserDto { get; set; }

    public string[] Roles => new[] { Admin, UserAdd };
        
    public bool BypassCache { get; }
    public string CacheKey {get;}
    public string? CacheGroupKey => "GetUsers";
}
