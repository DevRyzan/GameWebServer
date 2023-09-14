using FluentValidation;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Remove;

public class RemovePossibleRequestCommandValidator : AbstractValidator<RemovePossibleRequestCommandRequest>
{
    public RemovePossibleRequestCommandValidator()
    {
        RuleFor(x => x.RemovedPossibleRequestDto.Id)
            .NotEmpty().WithMessage("The id should not be empty")
            .NotNull().WithMessage("The id should not null")
            .GreaterThan(0).WithMessage("The id should be greater than 0");
    }
}
