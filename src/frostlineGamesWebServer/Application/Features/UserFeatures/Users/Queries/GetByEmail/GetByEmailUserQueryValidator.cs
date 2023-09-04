using FluentValidation;



namespace Application.Feature.UserFeatures.Users.Queries.GetByEmail
{
    public class GetByEmailUserQueryValidator : AbstractValidator<GetByEmailUserQueryRequest>
    {
        public GetByEmailUserQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("The email, should not be null.")
                .NotEmpty().WithMessage("The email, should not be empty.")
                .EmailAddress().WithMessage("Kindly enter a valid Email Address. ERROR!");

        }
    }
}
