using FluentValidation;


namespace Application.Feature.UserFeatures.Users.Command.Remove
{
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommandRequest>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("The id, should not be empty.")
                .NotNull().WithMessage("The id, should not be null.");
        }
    }
}
