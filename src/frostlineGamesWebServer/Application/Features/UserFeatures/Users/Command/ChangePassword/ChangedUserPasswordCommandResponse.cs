using Core.Application.Dtos;
using Core.Security.Enums;

namespace Application.Feature.UserFeatures.Users.Command.ChangePassword;

public class ChangedUserPasswordCommandResponse : IDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public ChangedPasswordResponseDto CreateResponseDto()
    {
        return new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            RequiredAuthenticatorType = RequiredAuthenticatorType
        };
    }

    public class ChangedPasswordResponseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    }
}
