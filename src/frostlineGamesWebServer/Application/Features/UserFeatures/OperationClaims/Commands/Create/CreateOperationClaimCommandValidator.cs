using FluentValidation;


namespace Application.Feature.UserFeatures.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(30);
        }
    }
}
