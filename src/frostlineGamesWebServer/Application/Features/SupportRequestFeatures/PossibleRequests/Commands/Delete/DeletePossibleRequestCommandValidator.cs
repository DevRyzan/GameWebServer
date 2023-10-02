using FluentValidation;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;

public class DeletePossibleRequestCommandValidator : AbstractValidator<DeletePossibleRequestCommandRequest>
{
    public DeletePossibleRequestCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("The id should not be empty")
            .NotNull().WithMessage("The id should not be null")
            .GreaterThan(0).WithMessage("The id should not be greater than 0.");

    }
}
