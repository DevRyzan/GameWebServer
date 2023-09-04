using FluentValidation;


namespace Application.Feature.UserFeatures.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimCommandValidator()
        {
            RuleFor(c => c.UserId);
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
