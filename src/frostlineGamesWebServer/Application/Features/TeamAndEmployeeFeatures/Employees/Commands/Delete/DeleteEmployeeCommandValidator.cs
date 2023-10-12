using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommandRequest>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull().WithMessage("The userId should not be empty.");
    }
}