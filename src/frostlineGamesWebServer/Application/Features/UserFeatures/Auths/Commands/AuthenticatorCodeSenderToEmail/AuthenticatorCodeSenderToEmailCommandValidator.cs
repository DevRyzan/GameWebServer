using FluentValidation;


namespace Application.Feature.UserFeatures.Auths.Commands.AuthenticatorCodeSenderToEmail
{
    public class AuthenticatorCodeSenderToEmailCommandValidator : AbstractValidator<AuthenticatorCodeSenderToEmailCommand>
    {
        public AuthenticatorCodeSenderToEmailCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("The user id, should not be empty.")
                .NotNull().WithMessage("The user id, should not be null.")
                .WithMessage("The user id, should be greater than 0.");
        }
    }
}
