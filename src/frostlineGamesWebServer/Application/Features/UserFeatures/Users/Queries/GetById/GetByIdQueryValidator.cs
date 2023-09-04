using FluentValidation;


namespace Application.Feature.UserFeatures.Users.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQueryRequest>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("The id, should not be empty.")
                .NotNull().WithMessage("The id, should not be null.");
        }
    }
}
