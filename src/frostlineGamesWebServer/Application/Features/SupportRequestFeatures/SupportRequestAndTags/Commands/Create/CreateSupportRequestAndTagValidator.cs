using FluentValidation;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Create;
public class CreateSupportRequestAndTagValidator : AbstractValidator<CreateSupportRequestAndTagCommandRequest>
{
    public CreateSupportRequestAndTagValidator()
    {
        RuleFor(x => x.CreatedSupportRequestAndTagDto.RequestId).NotEmpty().NotNull();
        RuleFor(x => x.CreatedSupportRequestAndTagDto.TagId).NotEmpty().NotNull();
    }
}

