namespace Core.Security.Dtos.ForgotPassword;
public class ChangePasswordForForgotPasswordDto
{
    public string Password { get; set; }
    public ChangePasswordForForgotPasswordDto()
    {
        
    }
    public ChangePasswordForForgotPasswordDto(string password)
    {
        Password = password;
    }
}
