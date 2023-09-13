using FluentValidation;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByTagIdPossibleRequest;
public class GetByIdTagIdPossibleQueryValidator : AbstractValidator<GetByTagIdPossibleRequestQuery>
{
    public GetByIdTagIdPossibleQueryValidator()
    {
        RuleFor(x => x.GetByTagIdPossibleRequestDto.TagId)
            .NotEmpty().WithMessage("The tag id should not be empty.")
            .NotNull().WithMessage("The tag id should not be null.")
            .GreaterThan(0).WithMessage("The tag id should be greater than 0.");
    }
}

