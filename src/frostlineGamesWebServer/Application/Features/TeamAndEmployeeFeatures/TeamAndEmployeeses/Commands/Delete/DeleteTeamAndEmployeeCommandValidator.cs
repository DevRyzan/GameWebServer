using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Delete;

public class DeleteTeamAndEmployeeCommandValidator : AbstractValidator<DeleteTeamAndEmployeesCommandRequest>
{
    public DeleteTeamAndEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("The id, should not be null.")
            .NotEmpty().WithMessage("The id, should not be empty.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}
