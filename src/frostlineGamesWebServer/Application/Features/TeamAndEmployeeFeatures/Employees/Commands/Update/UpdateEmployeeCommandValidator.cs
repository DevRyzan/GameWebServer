using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommandRequest>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull().WithMessage("The Id should not be empty.");

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty()
            .WithMessage("The userId should not be empty.");
    }
}