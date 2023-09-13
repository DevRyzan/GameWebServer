using FluentValidation;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.CreateList;

public class CreateListSupportRequestAndTagValidator : AbstractValidator<CreateListSupportRequestAndTagCommandRequest>
{
    public CreateListSupportRequestAndTagValidator()
    {
        RuleFor(x => x.SupportRequestId).NotNull().NotEmpty();
        RuleFor(x => x.TagIds).NotEmpty().NotNull();
    }
}
