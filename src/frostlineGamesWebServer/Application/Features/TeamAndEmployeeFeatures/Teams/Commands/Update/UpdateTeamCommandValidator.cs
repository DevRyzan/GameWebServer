using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Update;


public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommandRequest>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The id, should not be empty.")
            .NotNull().WithMessage("The id, should not be null.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("The name, should not be null.")
            .NotEmpty().WithMessage("The name, should not be empty.");

        RuleFor(x => x.Status)
            .NotNull().WithMessage("The status, should not be null.")
            .NotEmpty().WithMessage("The status, should not be empty.")
            .Must(x => x == false || x == true).WithMessage("The status, should be true or false.");

    }
}