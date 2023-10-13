using Application.Service.AuthService;
using Application.Service.EmailAuthenticatorService;
using Application.Service.OperationClaimService;
using Application.Service.UserOperationClaimService;
using Application.Services.BardServices; 
using Application.Services.EmployeeService; 
using Application.Services.SubscriptionServices; 
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestCategoryService;
using Application.Services.SupportRequestServices.SupportRequestCommentService;
using Application.Services.SupportRequestServices.SupportRequestService;
using Application.Services.SupportRequestServices.TagService;
using Application.Services.TeamAndEmployeeService;
using Application.Services.TeamService;
using Application.Services.UserDetailService;
using Application.Services.UserServices.UserDetailService;
using Application.Services.UserServices.UserService;
using Core.Application.Caching;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Rules;
using Core.Application.Pipelines.Validation;
using Core.Application.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
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

        services.AddSingleton<IRandomCodeGenerator, RandomCodeGenerator>();

        #region Core
        services.AddSingleton<LoggerServiceBase, FileLogger>(); 
        services.AddSingleton<IEmailService, EmailManager>();
        services.AddSingleton<IMailService, MailManager>();
        services.AddSingleton<IRandomCodeGenerator, RandomCodeGenerator>();
        #endregion

        #region Bard
        services.AddScoped<IBardService, BardManager>();
        #endregion

        #region User

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserDetailService, UserDetailManager>(); 
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IEmailAuthenticatorService, EmailAuthenticatorManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        #endregion

        #region TeamAndEmployee
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<ITeamService, TeamManager>();
        services.AddScoped<ITeamAndEmployeeService, TeamAndEmployeeManager>();
        #endregion

        #region SupportRequest

        services.AddScoped<ITagService, TagManager>();
        services.AddScoped<ISupportRequestService, SupportRequestManager>();
        services.AddScoped<ISupportRequestCommentService, SupportRequestCommentManager>();
        services.AddScoped<ISupportRequestCategoryService, SupportRequestCategoryManager>();
        services.AddScoped<ISupportRequestAndTagService, SupportRequestAndTagManager>();
        services.AddScoped<ISupportRequestAndSupportRequestCategoryService, SupportRequestAndSupportRequestCategoryManager>();
        services.AddScoped<IPossibleRequestService, PossibleRequestManager>();
        services.AddScoped<IPossibleRequestAndTagService, PossibleRequestAndTagManager>();
        #endregion

        #region Subscription
        services.AddScoped<ISubscriptionService, SubscriptionManager>();
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
