using FluentValidation;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommandRequest>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull()
                .NotEmpty().WithMessage("The userId should not be empty.");
        }
    }
}
