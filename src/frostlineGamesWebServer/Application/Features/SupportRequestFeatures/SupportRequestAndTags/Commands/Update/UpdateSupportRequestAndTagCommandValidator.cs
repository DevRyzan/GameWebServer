using FluentValidation;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Update;
public class UpdateSupportRequestAndTagCommandValidator : AbstractValidator<UpdateSupportRequestAndTagCommandRequest>
{
    public UpdateSupportRequestAndTagCommandValidator()
    {
        RuleFor(c => c.RequestId).GreaterThan(0);
        RuleFor(c => c.TagId).GreaterThan(0);
    }
}

