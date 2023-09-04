using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Enums;
using FluentValidation;

namespace Application.Feature.UserFeatures.Auths.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserForRegisterDto.Email)
            .NotEmpty().WithMessage("The email, should not be empty.")
            .NotNull().WithMessage("The email, should not be null.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .Matches("^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$").WithMessage(ExceptionMessageKeys.EmailCharValid);

        RuleFor(c => c.UserForRegisterDto.FirstName)
            .NotNull().WithMessage("The first name, should not be null.")
            .NotEmpty().WithMessage(ExceptionMessageKeys.FirstNameNotNull)
            .MinimumLength(4).WithMessage("The first name, should be minimum length 6.")
            .MaximumLength(40).WithMessage("The first name, should be maximum length 40.");

        RuleFor(c => c.UserForRegisterDto.LastName)
            .NotNull().WithMessage("The last name, should not be null.")
            .NotEmpty().WithMessage(ExceptionMessageKeys.LastNameNotNull)
            .MinimumLength(4).WithMessage("The last name, should be minimum length 6.")
            .MaximumLength(40).WithMessage("The last name, should be maximum length 40.");

        RuleFor(c => c.UserForRegisterDto.Password)
            .NotEmpty().WithMessage("The password, should not be empty.")
            .NotNull().WithMessage("The password, should not be null.")
            .MinimumLength(6).WithMessage("The password, should be minimum length 6.")
            .MaximumLength(40).WithMessage("The password, should be maximum length 40.")
            .Matches(@"[A-Z]+").WithMessage("The password should contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("The password should contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("The password should contain at least one number.")
            .Matches(@"[\!\?\*\.]*$").WithMessage("The password should contain at least one (!? *.).");
         
    }

}
