using FluentValidation;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.EditComment;

public class EditCommentSupportRequestCommandValidator : AbstractValidator<EditCommentSupportRequestCommandRequest>
{
    public EditCommentSupportRequestCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();

    }
}
