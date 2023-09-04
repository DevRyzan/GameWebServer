using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.UserFeatures.Users.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;

namespace Application.Feature.UserFeatures.Users.Command.Update;

public class UpdateUserCommandRequest : IRequest<UpdatedUserCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    //Only Admin and Staff can Action
    public string[] Roles => new[] { Admin, UserUpdate };
}
