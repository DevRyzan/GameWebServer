using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.UserRepositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FrostlineGamesDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("FrostlineGamesWebServerConnection")
        ));

        #region Core
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>(); 
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        #endregion

        #region User
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>(); 
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>(); 
        #endregion

        return services;
    }
}
