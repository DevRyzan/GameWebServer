using Core.Application.Dtos;
using Core.Security.Enums;
using static Application.Feature.UserFeatures.Users.Command.ChangePassword.ChangedUserPasswordCommandResponse;

namespace Application.Feature.UserFeatures.Users.Command.ChangeEmail
{
    public class ChangedUserEmailCommandResponse : IDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public ChangedEmailResponseDto CreateResponseDto()
        {
            return new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                RequiredAuthenticatorType = RequiredAuthenticatorType
            };
        }

        public class ChangedEmailResponseDto
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }
    }
}
