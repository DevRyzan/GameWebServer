using FluentValidation;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Update;

public class UpdateRequestAndCategoryCommandValidator: AbstractValidator<UpdateSupportRequestAndCategoryCommandRequest>
{
    public UpdateRequestAndCategoryCommandValidator()
    {
        RuleFor(c => c.RequestId)
            .NotNull().WithMessage("The request id, should not be null.")
            .NotEmpty().WithMessage("The request id, should not be empty.")
            .GreaterThan(0).WithMessage("The request id, should be greater than 0.");

        RuleFor(c => c.CategoryId)
            .NotEmpty().WithMessage("The category id, should not be empty.")
            .NotNull().WithMessage("The category id, should not be null.")
            .GreaterThan(0).WithMessage("The category id should be greater than 0.");
    }
}
