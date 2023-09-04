using FluentValidation;

namespace Application.Feature.UserFeatures.Users.Command.ChangePassword;

public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommandRequest>
{
    public ChangeUserPasswordCommandValidator()
    {
        RuleFor(c => c.UserForChangePasswordDto.Password)
            .NotEmpty().WithMessage("The password should not be empty.")
            .NotNull().WithMessage("The password should not be null.")
            .MinimumLength(6).WithMessage("The password should be minimum 6 length.")
            .MaximumLength(40).WithMessage("The password should be maximum 30 length.")
            .Matches(@"[A-Z]+").WithMessage("The password should contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("The password should contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("The password should contain at least one number.")
            .Matches(@"[\!\?\*\.]*$").WithMessage("The password should contain at least one (!? *.).");

        RuleFor(x => x.UserForChangePasswordDto.OldPassword)
            .NotNull().WithMessage("The old password, should not be null.")
            .NotEmpty().WithMessage("The old password, should not be empty.");

        RuleFor(x => x.UserIP)
            .NotEmpty().WithMessage("The user IP, should not be empty.")
            .NotNull().WithMessage("The user IP, should not be null.");
    }
}
