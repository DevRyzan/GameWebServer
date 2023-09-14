using FluentValidation;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestCategoryCommandValidator : AbstractValidator<RemoveSupportRequestCategoryCommand>
{
    public RemoveSupportRequestCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("The id, should not be null.")
            .NotEmpty().WithMessage("The id, should not be empty.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}
