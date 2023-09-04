using FluentValidation;


namespace Application.Feature.UserFeatures.Auths.Commands.EnableEmailAuthenticator
{
    public class EnableEmailAuthenticatorCommandValidator : AbstractValidator<EnableEmailAuthenticatorCommand>
    {
        public EnableEmailAuthenticatorCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("The user id, should not be empty.")
                .NotNull().WithMessage("The user id, should not be null.")
                 .WithMessage("The user id, should be greater than 0.");

            RuleFor(x => x.VerifyEmailLink)
                .NotEmpty().WithMessage("The verify email link, should not be empty.")
                .NotNull().WithMessage("The verify email link, should not be null.");
        }
    }
}
