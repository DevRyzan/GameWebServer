namespace Application.Feature.UserFeatures.Users.Dtos;
public class UserForChangePasswordDto
{
    public string OldPassword { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
}
