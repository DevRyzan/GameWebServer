using FluentValidation;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;

public class UpdatePossibleRequestCommandValidator : AbstractValidator<UpdatePossibleRequestCommandRequest>
{
    public UpdatePossibleRequestCommandValidator()
    {
        RuleFor(c => c.UpdatedPossibleRequestDto.Id)
            .NotEmpty().WithMessage("The id should not be empty.")
            .NotNull().WithMessage("The id should not be null.")
            .GreaterThan(0).WithMessage("The id should be greater than 0.");

        RuleFor(c => c.UpdatedPossibleRequestDto.RequestName)
            .MinimumLength(2);

        RuleFor(c => c.UpdatedPossibleRequestDto.Title)
            .MinimumLength(2);


        RuleFor(c => c.UpdatedPossibleRequestDto.Comment)
            .MinimumLength(2);

        RuleFor(c => c.UpdatedPossibleRequestDto.SupportRequestCategoryId)
            .GreaterThan(0);

    }
}
