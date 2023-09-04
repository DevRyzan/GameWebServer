using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities; 

namespace Application.Service.Repositories;

public interface IEmailAuthenticatorRepository: IAsyncReadRepository<EmailAuthenticator, int>, IReadRepository<EmailAuthenticator, int>, IAsyncWriteRepository<EmailAuthenticator, int>, IWriteRepository<EmailAuthenticator, int>
{

}
