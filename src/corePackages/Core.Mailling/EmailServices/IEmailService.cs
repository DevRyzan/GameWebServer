using Core.Emailling.Models;

namespace Core.Emailling.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(Email result);
        void SendEmailAsync(Email result);
    }
}
