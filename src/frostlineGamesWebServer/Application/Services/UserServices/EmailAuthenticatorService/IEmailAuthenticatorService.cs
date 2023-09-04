using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Service.EmailAuthenticatorService;

public interface IEmailAuthenticatorService 
{
    Task<EmailAuthenticator> Create(EmailAuthenticator emailAuthenticator);
    Task<EmailAuthenticator> Update(EmailAuthenticator emailAuthenticator);
    Task<EmailAuthenticator> Delete(EmailAuthenticator emailAuthenticator);
    Task<EmailAuthenticator> Remove(EmailAuthenticator emailAuthenticator);

    Task<EmailAuthenticator> GetById(int id);
    Task<bool> IsVerified(Guid userId);
    Task<IPaginate<EmailAuthenticator>> GetListByVerified(bool isVerified, int index = 0, int size = 10);

}
