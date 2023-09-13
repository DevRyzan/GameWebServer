using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Update;
using FluentValidation;

namespace Application.Feature.SupportRequestFeatures.SupportRequestCategories.Commands.Update
{
    public class UpdateSupportRequestCategoryCommandValidator : AbstractValidator<UpdateSupportRequestCategoryCommand>
    {
        public UpdateSupportRequestCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("The id, should not be null.")
                .NotEmpty().WithMessage("The id, should not be empty.")
                .GreaterThan(0).WithMessage("The id, should br greater than 0.");

              
        }
    }
}
