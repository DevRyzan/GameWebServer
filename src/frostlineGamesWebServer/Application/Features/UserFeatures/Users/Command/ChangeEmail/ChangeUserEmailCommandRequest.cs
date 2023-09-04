
using Application.Feature.UserFeatures.Users.Dtos;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.UserFeatures.Users.Command.ChangeEmail.ChangedUserEmailCommandResponse;

namespace Application.Feature.UserFeatures.Users.Command.ChangeEmail
{
    public class ChangeUserEmailCommandRequest : IRequest<ChangedUserEmailCommandResponse>, ITransactionalRequest
    {
        public UserForChangeEmailDto UserForChangeEmailDto { get; set; }
        public string? AuthenticatorCode { get; set; }
        public Guid Id { get; set; }
        public string UserIP { get; set; }
    }
}
