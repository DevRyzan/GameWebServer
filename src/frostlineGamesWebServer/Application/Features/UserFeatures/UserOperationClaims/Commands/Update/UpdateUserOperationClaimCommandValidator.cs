using FluentValidation;


namespace Application.Feature.UserFeatures.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimCommandValidator : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimCommandValidator()
        {
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
