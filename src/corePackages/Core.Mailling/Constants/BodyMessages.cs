using Microsoft.Extensions.Configuration;

namespace Core.Emailling.Constants;
public static class BodyMessages
{
    public const string PasswordChanged = "YOUR PASSWORD CHANGED AT {DateTime.UtcNow} ++++++++ LİNK GELECEK";
    public const string PasswordWillChange = "YOUR PASSWORD WILL CHANGE AT ++++++++ LİNK GELECEK:   ";
    public const string OrderConfirmed = "Email authenticator don't exists.";
    public const string NickNameChanged = "YOUR NickName CHANGED AT {DateTime.UtcNow} ++++++++ LİNK GELECEK";
    public const string EmailChanged = "Email authenticator don't exists.";
    public const string AccountFrozen = "Email authenticator don't exists.";
    public const string AccountDeleted = "Email authenticator don't exists.";

    public const string SendEmailForCreateSupportRequest = "Send email for Create Support Request";
    public const string SendEmailForCreateSupportRequestComment = "Send email for Create Support Request Comment";
    public const string SendMailForRegisterUser = "Send Mail For Register User";


    public const string ForgotPassword = " ŞİFRE DEĞİŞTİRME İSTEĞİ Frostline Games hesabın için şifre değiştirme isteği aldık." +
        " Şifreni değiştirmek için aşağıdaki bağlantıya tıkla:  192.168.1.56:5010/Auth/VerifyEmailAuthenticator";
}
