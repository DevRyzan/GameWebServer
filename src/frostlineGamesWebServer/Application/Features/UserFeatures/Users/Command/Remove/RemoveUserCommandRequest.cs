using MediatR;
using Core.Application.Pipelines.Authorization;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using Core.Application.Transaction;

namespace Application.Feature.UserFeatures.Users.Command.Remove;

public class RemoveUserCommandRequest : IRequest<bool>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, UserDelete };
}
