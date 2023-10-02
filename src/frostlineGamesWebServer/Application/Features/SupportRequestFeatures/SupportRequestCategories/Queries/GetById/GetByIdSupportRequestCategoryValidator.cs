using FluentValidation;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.GetById;

public class GetByIdSupportRequestCategoryValidator : AbstractValidator<GetByIdSupportRequestCategoryQueryRequest>
{
    public GetByIdSupportRequestCategoryValidator()
    {
        RuleFor(x => x.GetByIdSupportRequestCategoryDto.Id)
            .NotNull().WithMessage("The id, should not be null.")
            .NotEmpty().WithMessage("The id, should not be empty.")
            .GreaterThan(0).WithMessage("The id, should greater than 0.");
    }
}
