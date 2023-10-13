using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;

public class CreateTeamAndEmployeesCommandValidator : AbstractValidator<CreateTeamAndEmployeesCommandRequest>
{
    public CreateTeamAndEmployeesCommandValidator()
    {
        RuleFor(x => x.TeamId)
            .NotNull().WithMessage("The team id, should not be null.")
            .NotEmpty().WithMessage("The team id, should not be empty.")
            .GreaterThan(0).WithMessage("The team id, should greater than 0.");

        RuleFor(x => x.EmployeeId);
    }
}
