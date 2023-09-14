using FluentValidation;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;

public class CreateRequestAndCategoryValidator : AbstractValidator<CreateSupportRequestAndCategoryCommandRequest>
{
    public CreateRequestAndCategoryValidator()
    {
        RuleFor(c => c.SupportRequestId)
            .NotNull().WithMessage("The request id, should not be null.")
            .NotEmpty().WithMessage("The request id, should not be empty.")
            .GreaterThan(0).WithMessage("The request id, should be greater than 0.");

        RuleFor(c => c.SupportRequestCategoryId)
            .NotEmpty().WithMessage("The category id, should not be empty.")
            .NotNull().WithMessage("The category id, should not be null.")
            .GreaterThan(0).WithMessage("The category id, should be greater than 0.");
    }
}

