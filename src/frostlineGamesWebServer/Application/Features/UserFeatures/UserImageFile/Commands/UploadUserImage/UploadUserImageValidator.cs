using FluentValidation;


namespace Application.Feature.UserFeatures.UserImageFile.Commands.UploadUserImage
{
    public class UploadUserImageValidator : AbstractValidator<UploadUserImageCommandRequest>
    {
        public UploadUserImageValidator()
        {

            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Files).NotEmpty().Must(t => t.Count <= 5);


        }
    }
}
