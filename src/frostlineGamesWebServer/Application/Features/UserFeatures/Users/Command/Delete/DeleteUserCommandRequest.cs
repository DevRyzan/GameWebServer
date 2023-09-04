using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.Users.Command.Delete;

public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, UserDelete };
}
