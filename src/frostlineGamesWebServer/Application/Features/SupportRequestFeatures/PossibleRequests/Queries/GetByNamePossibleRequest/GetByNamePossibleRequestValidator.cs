using Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByNamePossibleRequest;
using FluentValidation;


namespace Application.Feature.SupportRequestFeatures.PossibleRequests.Queries.GetByNamePossibleRequest
{
    public class GetByNamePossibleRequestValidator : AbstractValidator<GetByNamePossibleRequestQuery>
    {
        public GetByNamePossibleRequestValidator()
        {
            RuleFor(x => x.GetByNamePossibleRequestDto.Name)
                .NotEmpty().WithMessage("The request name should not be empty.")
                .NotNull().WithMessage("The request name should not be null.");
        }
    }
}
