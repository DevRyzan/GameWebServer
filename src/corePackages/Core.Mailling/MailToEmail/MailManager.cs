using Core.Emailling.Constants;
using Core.Emailling.EmailServices;
using Core.Emailling.Models;

namespace Core.Emailling.MailToEmail;
public class MailManager : IMailService
{
    private readonly IEmailService _emailService; 

    public MailManager(IEmailService emailService)
    {
        _emailService = emailService; 
    }

    public void SendAccountDeletedMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.AccountDeleted,
            Body = BodyMessages.AccountDeleted
        });
    }

    public void SendAccountFrozenMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.AccountFrozen,
            Body = BodyMessages.AccountFrozen
        });
    }

    public void SendEMailChangedMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.EmailChanged,
            Body = BodyMessages.EmailChanged
        });
    }

    public void SendNickNameChangedMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.NickNameChanged,
            Body = BodyMessages.NickNameChanged
        });
    }

    public void SendOrderConfirmedMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.OrderConfirmed,
            Body = BodyMessages.OrderConfirmed
        });
    }

    public async void SendPasswordChangedMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.PasswordChanged,
            Body = BodyMessages.PasswordChanged
        });
    }

    public async void SendAuthCodePasswordWillChangeMail(string email,string authCode)
    { 
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.PasswordWillChange,
            Body = BodyMessages.PasswordWillChange + authCode
        });
    }

    public void SendLinkForForgotPasswordToEMail(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.ForgotPassword,
            Body = BodyMessages.ForgotPassword
        });
    }

    public void SendEmailForCreateSupportRequest(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.SendEmailForCreateSupportRequest,
            Body = BodyMessages.SendEmailForCreateSupportRequest
        });
    }

    public void SendEmailForCreateSupportRequestComment(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.SendEmailForCreateSupportRequestComment,
            Body = BodyMessages.SendEmailForCreateSupportRequestComment
        });
    }

    public void SendMailForRegisterUser(string email)
    {
        _emailService.SendEmail(new Email
        {
            To = email,
            Subject = SubjectMessages.SendMailForRegisterUser,
            Body = BodyMessages.SendMailForRegisterUser
        });
    }
}
