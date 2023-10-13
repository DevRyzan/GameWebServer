using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;

public class DeleteCommandValidator : AbstractValidator<DeleteTeamCommandRequest>
{
    public DeleteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The id, should not be empty.")
            .NotNull().WithMessage("The id, should not be null.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}