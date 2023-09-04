using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Feature.UserFeatures.Users.Command.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("The id, should not be empty.")
                 .NotNull().WithMessage("The id, should not be null.");

            RuleFor(c => c.FirstName)
                 .NotEmpty().WithMessage("The first name, should not be empty.")
                 .NotNull().WithMessage("The first name, should not be null.")
                 .MinimumLength(2).WithMessage("The first name, should be minimum length 2.")
                 .MaximumLength(20).WithMessage("The first name, should be maximum length 20");


            RuleFor(c => c.LastName)
                .NotNull().WithMessage("The last name, should not be null.")
                .NotEmpty().WithMessage("The last name, should not be empty.")
                .MinimumLength(2).WithMessage("The last name, should be minimum length 2.")
                .MaximumLength(28).WithMessage("The last name, should be maximum length 28");
                

            RuleFor(c => c.Email)
                .NotNull().WithMessage("The email, should not be null.")
                .NotEmpty().WithMessage("The email, should not be empty.")
                .Must(BeAValidEmail).WithMessage("The email, should be valid.");


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
