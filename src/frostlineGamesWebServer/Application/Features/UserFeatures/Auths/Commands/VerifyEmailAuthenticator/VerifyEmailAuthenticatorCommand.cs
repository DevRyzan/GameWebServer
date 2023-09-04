using Application.Feature.UserFeatures.Auths.Rules;
using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR;

namespace Application.Feature.UserFeatures.Auths.Commands.VerifyEmailAuthenticator;

public class VerifyEmailAuthenticatorCommand : IRequest, ITransactionalRequest
{
    public string ActivationKey { get; set; }

    public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
    {
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;

        public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorRepository emailAuthenticatorRepository,
                                                      AuthBusinessRules authBusinessRules,
                                                      IUserRepository userRepository)
        {
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
        }
        public async Task Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            EmailAuthenticator? emailAuthenticator =
            await _emailAuthenticatorRepository.GetAsync(e => e.ActivationKey == request.ActivationKey);

            await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
            await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator);

            emailAuthenticator.ActivationKey = null;
            emailAuthenticator.IsVerified = true;
            emailAuthenticator.Status = true;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            User user = await _userRepository.GetAsync(x => x.Id == emailAuthenticator.UserId);
            user.Status = true;
            await _userRepository.UpdateAsync(user); 
        }
    }
}
