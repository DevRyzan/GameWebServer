using FluentValidation;


namespace Application.Feature.UserFeatures.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.UserForLoginDto.Email)
                .NotNull().WithMessage("The email, should not be null.")
                .NotEmpty().WithMessage("the email, should not be empty.")
                .EmailAddress().WithMessage("A valid email address is required.");


            RuleFor(c => c.UserForLoginDto.Password)
                .NotEmpty().WithMessage("The password, should not empty.")
                .NotNull().WithMessage("The password, should not be null.")
                .MinimumLength(6).WithMessage("The password should be minimum length 6.")
                .MaximumLength(40).WithMessage("The password, should be maximum length 40.");
        }
    }
}
