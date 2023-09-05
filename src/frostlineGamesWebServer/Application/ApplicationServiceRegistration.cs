using Application.Service.AuthService;
using Application.Service.EmailAuthenticatorService;
using Application.Service.OperationClaimService;
using Application.Service.UserDetailService;
using Application.Service.UserOperationClaimService;
using Application.Service.UserService;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Rules;
using Core.Application.Pipelines.Validation;
using Core.Application.Transaction;
using Core.Emailling.EmailServices;
using Core.Emailling.MailToEmail;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection; 

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddMemoryCache();

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 

        #region Core
        services.AddSingleton<IEmailService, EmailManager>();
        services.AddSingleton<IMailService, MailManager>();
        #endregion

        #region User

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserDetailService, UserDetailManager>(); 
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IEmailAuthenticatorService, EmailAuthenticatorManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        #endregion 

        return services;
    }
    public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, type);
            }
        }
        return services;
    }
}
