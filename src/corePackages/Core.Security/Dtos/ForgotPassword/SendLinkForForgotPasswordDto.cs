namespace Core.Security.Dtos.ForgotPassword;
public class SendLinkForForgotPasswordDto
{
    public string Email { get; set; }
    public SendLinkForForgotPasswordDto()
    {
            
    }
    public SendLinkForForgotPasswordDto(string email)
    {
        Email = email;
    }
}
