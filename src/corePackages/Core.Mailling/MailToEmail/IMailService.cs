namespace Core.Emailling.MailToEmail;

public interface IMailService
{
    void SendPasswordChangedMail(string email);
    void SendAuthCodePasswordWillChangeMail(string email, string authCode);
    void SendAccountDeletedMail(string email);
    void SendAccountFrozenMail(string email);
    void SendOrderConfirmedMail(string email);
    void SendNickNameChangedMail(string email);
    void SendEMailChangedMail(string email);
    void SendLinkForForgotPasswordToEMail(string email);
    void SendEmailForCreateSupportRequest(string email);
    void SendEmailForCreateSupportRequestComment(string email);
    void SendMailForRegisterUser(string email);
}
