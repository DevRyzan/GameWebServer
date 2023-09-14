using FluentValidation;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByTagNamePossibleRequest;


public class GetByTagNamePossibleRequestQueryValidator : AbstractValidator<GetByTagNamePossibleRequestQuery>
{
    public GetByTagNamePossibleRequestQueryValidator()
    {
        RuleFor(x => x.GetByTagNamePossibleRequestDto.TagName)
            .NotEmpty().WithMessage("The tag name should not be empty.")
            .NotNull().WithMessage("The tag name should not be null.");
    }
}
