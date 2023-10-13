using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Update;

public class UpdateTeamAndEmployeesCommandValidator : AbstractValidator<UpdateTeamAndEmployeesCommandRequest>
{
    public UpdateTeamAndEmployeesCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("The id, should not be null.")
            .NotEmpty().WithMessage("The id, should not be empty.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");

        RuleFor(x => x.EmployeeId);

        RuleFor(x => x.TeamId)
            .NotNull().WithMessage("The team id, should not be null.")
            .NotEmpty().WithMessage("The team id, should not be empty.")
            .GreaterThan(0).WithMessage("The team id, should greater than 0.");
    }
}