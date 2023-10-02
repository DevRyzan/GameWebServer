using FluentValidation;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Commands.Update;

public class UpdateSupportRequestCommentCommandValidator : AbstractValidator<UpdateSupportRequestCommentCommandRequest>
{
    public UpdateSupportRequestCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BardId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SupportRequestId).NotEmpty();


    }
}
