using Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.Create;
using FluentValidation;

namespace Application.Feature.SupportRequestFeatures.SupportRequestCategories.Commands.Create
{
    public class CreateSupportRequestCategoryCommandValidator : AbstractValidator<CreateSupportRequestCategoryCommand>
    {
        public CreateSupportRequestCategoryCommandValidator()
        {

        }
    }
}
