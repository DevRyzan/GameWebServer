using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Feature.UserFeatures.Users.Command.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.CreateUserDto.FirstName).NotEmpty().MinimumLength(2);

            //RuleFor(c => c.FirstName)
            //    .NotEmpty().WithMessage("The first name,should not be empty.")
            //    .NotNull().WithMessage("The first name,should not be null.")
            //    .MinimumLength(2).WithMessage("The first name,should be minimum length 2.")
            //    .MaximumLength(20).WithMessage("The first name, should be maximum length 20");


            //RuleFor(c => c.LastName)
            //    .NotNull().WithMessage("The last name, should not be null.")
            //    .NotEmpty().WithMessage("The last name, should not be empty.")
            //    .MinimumLength(2).WithMessage("The last name, should be minimum length 2.")
            //    .MaximumLength(28).WithMessage("The last name, should be maximum length 28");


            //RuleFor(c => c.Email)
            //    .NotNull().WithMessage("The email, should not be null.")
            //    .NotEmpty().WithMessage("The email, should not be empty.")
            //    .Must(BeAValidEmail).WithMessage("The email, should be valid.");
                

            //RuleFor(c => c.Password)
            //    .NotEmpty().WithMessage("The password, should not be empty.")
            //    .NotNull().WithMessage("The password, should not be null.")
            //    .MinimumLength(6).WithMessage("The password, should be minimum length 6.")
            //    .MaximumLength(40).WithMessage("The password, should be maximum length 40.")
            //    .Matches(@"[A-Z]+").WithMessage("The password should contain at least one uppercase letter.")
            //    .Matches(@"[a-z]+").WithMessage("The password should contain at least one lowercase letter.")
            //    .Matches(@"[0-9]+").WithMessage("The password should contain at least one number.")
            //    .Matches(@"[\!\?\*\.]*$").WithMessage("The password should contain at least one (!? *.).");

        }

        private bool BeAValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
