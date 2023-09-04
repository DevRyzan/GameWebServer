using Application.Service.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Service.EmailAuthenticatorService;

public class EmailAuthenticatorManager : IEmailAuthenticatorService
{
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

    public EmailAuthenticatorManager(IEmailAuthenticatorRepository emailAuthenticatorRepository)
    {
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
    }

    public Task<EmailAuthenticator> Create(EmailAuthenticator emailAuthenticator)
    {
        throw new NotImplementedException();
    }

    public Task<EmailAuthenticator> Delete(EmailAuthenticator emailAuthenticator)
    {
        throw new NotImplementedException();
    }

    public Task<EmailAuthenticator> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IPaginate<EmailAuthenticator>> GetListByVerified(bool isVerified, int index = 0, int size = 10)
    {
        IPaginate<EmailAuthenticator> emailAuthenticatorList = await _emailAuthenticatorRepository.GetListAsync(a => a.IsVerified == isVerified, index: index, size: size);
        return emailAuthenticatorList;
    }

    public async Task<bool> IsVerified(Guid userId)
    {
        var isVerified = await _emailAuthenticatorRepository.GetAsync(x => x.UserId.Equals(userId));
        return isVerified.IsVerified;
    }

    public Task<EmailAuthenticator> Remove(EmailAuthenticator emailAuthenticator)
    {
        throw new NotImplementedException();
    }

    public Task<EmailAuthenticator> Update(EmailAuthenticator emailAuthenticator)
    {
        throw new NotImplementedException();
    }
}
