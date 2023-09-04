using FluentValidation;


namespace Application.Feature.UserFeatures.Users.Command.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommandRequest>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("The id, should not be empty.")
                .NotNull().WithMessage("The id, should not be null.");
        }
    }
}
