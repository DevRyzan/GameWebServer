using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories.UserRepositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, FrostlineGamesDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(FrostlineGamesDbContext context) : base(context)
    {

    }
}
