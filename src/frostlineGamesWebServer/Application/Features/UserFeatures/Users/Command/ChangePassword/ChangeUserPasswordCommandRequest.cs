using Application.Feature.UserFeatures.Users.Dtos;
using Core.Application.Transaction;
using MediatR;
namespace Application.Feature.UserFeatures.Users.Command.ChangePassword;

public class ChangeUserPasswordCommandRequest : IRequest<ChangedUserPasswordCommandResponse>, ITransactionalRequest
{
    public UserForChangePasswordDto UserForChangePasswordDto { get; set; }
    public Guid Id { get; set; }
    public string UserIP { get; set; }
}
