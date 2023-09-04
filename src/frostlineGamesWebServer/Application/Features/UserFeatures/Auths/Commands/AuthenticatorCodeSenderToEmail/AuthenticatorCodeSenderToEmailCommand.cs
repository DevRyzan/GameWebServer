using Application.Feature.UserFeatures.Auths.Rules;
using Application.Service.AuthService;
using Application.Service.Repositories;
using Application.Service.UserService;
using Core.Application.Transaction;
using Core.Emailling.EmailServices;
using Core.Emailling.Models;
using Core.Security.Entities;
using Core.Security.Enums;
using MediatR;
using System.Web;

namespace Application.Feature.UserFeatures.Auths.Commands.AuthenticatorCodeSenderToEmail;

public class AuthenticatorCodeSenderToEmailCommand : IRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public class AuthenticatorCodeSenderToEmailCommandHandler : IRequestHandler<AuthenticatorCodeSenderToEmailCommand>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IEmailService _emailService;
        private readonly AuthBusinessRules _authBusinessRules;

        public AuthenticatorCodeSenderToEmailCommandHandler(IUserService userService, IAuthService authService, IEmailAuthenticatorRepository emailAuthenticatorRepository, IEmailService emailService, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _authService = authService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _emailService = emailService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task Handle(AuthenticatorCodeSenderToEmailCommand request, CancellationToken cancellationToken)
        {
            User user = await _userService.GetById(request.UserId);
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

            user.AuthenticatorType = AuthenticatorType.Email;
            await _userService.Update(user);

            EmailAuthenticator emailAuthenticator = await _authService.CreateEmailAuthenticator(user);
            emailAuthenticator.CreatedDate = DateTime.UtcNow;
            EmailAuthenticator addedEmailAuthenticator =
                await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);

            _emailService.SendEmail(new Email
            {
                To = user.Email,
                Subject = "FrostlineGames",
                Body = $"Click on the link to verify your email: ?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}"
            });
             
        }
    }
}
