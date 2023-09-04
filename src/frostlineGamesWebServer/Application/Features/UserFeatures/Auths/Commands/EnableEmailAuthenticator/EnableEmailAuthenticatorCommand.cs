using Application.Service.AuthService;
using Application.Service.Repositories;
using Application.Service.UserService;
using Core.Emailling.EmailServices;
using Core.Security.Entities;
using Core.Security.Enums;
using MediatR;
using System.Web;
using Core.Emailling.Models;
using Application.Feature.UserFeatures.Auths.Rules;
using Core.Application.Transaction;

namespace Application.Feature.UserFeatures.Auths.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommand : IRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public string VerifyEmailLink { get; set; }

    public EnableEmailAuthenticatorCommand()
    {
        VerifyEmailLink = string.Empty;
    }

    public EnableEmailAuthenticatorCommand(string activationKey)
    {
        VerifyEmailLink = activationKey;
    }

    public class EmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IEmailService _emailService;
        private readonly AuthBusinessRules _authBusinessRules;

        public EmailAuthenticatorCommandHandler(IUserService userService,
                                                IAuthService authService,
                                                IEmailAuthenticatorRepository emailAuthenticatorRepository,
                                                IEmailService emailService,
                                                AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _authService = authService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _emailService = emailService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            User user =await _userService.GetById(request.UserId);
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

            user.AuthenticatorType = AuthenticatorType.Email;
            await _userService.Update(user);

            EmailAuthenticator emailAuthenticator = await _authService.CreateEmailAuthenticator(user);
            emailAuthenticator.CreatedDate = DateTime.UtcNow;
            EmailAuthenticator addedEmailAuthenticator =
            await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);
            //var toEmailList = new List<MailboxAddress>
            //{
            //new($"{user.FirstName} {user.LastName}",user.Email)
            //};

            _emailService.SendEmail(new Email
            {
                To = user.Email,
                Subject = "FrostlineGames",
                Body = $"Click on the link to verify your email: {request.VerifyEmailLink}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}"
            });
             
        }
    }
}