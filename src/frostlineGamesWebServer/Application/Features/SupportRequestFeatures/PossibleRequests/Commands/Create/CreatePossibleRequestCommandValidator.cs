using FluentValidation;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Create;


public class CreatePossibleRequestCommandValidator : AbstractValidator<CreatePossibleRequestCommand>
{
    public CreatePossibleRequestCommandValidator()
    {
        RuleFor(c => c.RequestName)
            .MinimumLength(2);

        RuleFor(c => c.Title)
            .MinimumLength(2);

        RuleFor(c => c.Comment)
            .MinimumLength(2);

        RuleFor(c => c.SupportRequestCategoryId)
            .GreaterThan(0);

    }
}
