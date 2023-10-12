
using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;


public class RemoveEmployeeCommandValidator : AbstractValidator<RemoveEmployeeCommandRequest>
{
    public RemoveEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty().WithMessage("The Id should not be empty.");
    }
}
