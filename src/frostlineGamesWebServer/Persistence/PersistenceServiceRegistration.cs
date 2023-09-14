using Application.Service.Repositories;
using Application.Services.Repositories.BardRepositories;
using Application.Services.Repositories.FileRepositories;
using Application.Services.Repositories.SupportRequestRepositories;
using Application.Services.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.BardRepositories;
using Persistence.Repositories.FileRepositories;
using Persistence.Repositories.SupportRequestRepositories;
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

        #region Bard
        services.AddScoped<IBardRepository, BardRepository>();
        #endregion

        #region User
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        #endregion

        #region File
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IUserDetailImageFileRepository, UserDetailImageFileRepository>();
        #endregion

        #region SupportRequest
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISupportRequestRepository, SupportRequestRepository>();
        services.AddScoped<ISupportRequestCommentRepository, SupportRequestCommentRepository>();
        services.AddScoped<ISupportRequestCategoryRepository, SupportRequestCategoryRepository>();
        services.AddScoped<ISupportRequestAndTagRepository, SupportRequestAndTagRepository>();
        services.AddScoped<ISupportRequestAndSupportRequestCategoryRepository, SupportRequestAndSupportRequestCategoryRepository>();
        services.AddScoped<IPossibleRequestRepository, PossibleRequestRepository>();
        services.AddScoped<IPossibleRequestAndTagRepository, PossibleRequestAndTagRepository>();
        #endregion


        return services;
    }
}
