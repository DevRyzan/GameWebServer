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
            
        });

         

        //services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 

        //#region Core
        //services.AddSingleton<LoggerServiceBase, FileLogger>();
        //services.AddSingleton<IEmailService, EmailManager>();
        //services.AddSingleton<IMailService, MailManager>();
        //services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        //#endregion


        //#region Abilities
        //services.AddScoped<IAbilityService, AbilityManager>();
        //services.AddScoped<IAbilityAndAbilityComboService, AbilityAndAbilityComboManager>();
        //services.AddScoped<IAbilityAndAbilityCategoryService, AbilityAndAbilityCategoryManager>();
        //services.AddScoped<IAbilityAndAbilityLevelService, AbilityAndAbilityLevelManager>();

        //services.AddScoped<IAbilityCategoryService, AbilityCategoryManager>();
        //services.AddScoped<IAbilityComboService, AbilityComboManager>();
        //services.AddScoped<IAbilityDetailService, AbilityDetailManager>();
        //services.AddScoped<IAbilityDamageTypeService, AbilityDamageTypeManager>();
        //services.AddScoped<IAbilityEffectStatService, AbilityEffectStatManager>();
        //services.AddScoped<IAbilityDamageTypeService, AbilityDamageTypeManager>(); 
        //services.AddScoped<IAbilityTargetTypeService, AbilityTargetTypeManager>();
 
        //services.AddScoped<IAbilityLevelService, AbilityLevelManager>(); 
        //services.AddScoped<IAbilityTypeService, AbilityTypeManager>(); 
        //services.AddScoped<IEffectTypeService, EffectTypeManager>();

        //#endregion


        //#region User

        //services.AddScoped<IAuthService, AuthManager>();
        //services.AddScoped<IUserService, UserManager>();
        //services.AddScoped<IUserDetailService, UserDetailManager>();
        //services.AddScoped<IBannedService, BannedManager>();
        //services.AddScoped<IBannedAndUserDetailService, BannedAndUserDetailManager>();
        //services.AddScoped<IOperationClaimService, OperationClaimManager>();
        //services.AddScoped<IEmailAuthenticatorService, EmailAuthenticatorManager>();
        //services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        //#endregion 


        //#region Bard

        //services.AddScoped<IBardService, BardManager>();
        //services.AddScoped<IBardDetailService, BardDetailManager>();
        //services.AddScoped<IBardIconService, BardIconManager>();
        //services.AddScoped<IEloRankService, EloRankManager>();
        //services.AddScoped<IBardAndEloRankService, BardAndEloRankManager>();
        //services.AddScoped<ILevelService, LevelManager>();
        //services.AddScoped<IBardAndLevelService, BardAndLevelManager>(); 
        //services.AddScoped<IBardAndMatchesRateService, BardAndMatchesRateManager>();
        //services.AddScoped<IBardEloRankPointService, BardEloRankPointManager>(); 
        //services.AddScoped<IBardExperiencePointService, BardExperiencePointManager>();   
        //services.AddScoped<IMatchesRateService, MatchesRateManager>(); 
        //services.AddScoped<ICreditService, CreditManager>(); 
        //services.AddScoped<IContributionPointService, ContributionPointManager>(); 
        //services.AddScoped<IBardAndHeroService, BardAndHeroManager>(); 
        //services.AddScoped<IBardAndSkinService, BardAndSkinManager>(); 
        //#endregion


        //#region SupportRequest

        //services.AddScoped<ISupportRequestService, SupportRequestManager>(); 
        //services.AddScoped<ISupportRequestCommentService, SupportRequestCommentManager>();
        //services.AddScoped<ISupportRequestCategoryService, SupportRequestCategoryManager>();
        //services.AddScoped<ISupportRequestAndTagService, SupportRequestAndTagManager>();
        //services.AddScoped<ISupportRequestAndSupportRequestCategoryService, SupportRequestAndSupportRequestCategoryManager>();
        //services.AddScoped<ITagService, TagManager>();
        //services.AddScoped<IPossibleRequestService, PossibleRequestManager>();
        //services.AddScoped<IPossibleRequestAndTagService, PossibleRequestAndTagManager>();
        //services.AddScoped<ISupportRequestCommentService, SupportRequestCommentManager>(); 
        //#endregion


        //#region Hero

        //services.AddScoped<IHeroStatService, HeroStatManager>();
        //services.AddScoped<IHeroService, HeroManager>();
        //services.AddScoped<IHeroDetailService, HeroDetailManager>();
        //services.AddScoped<IHeroAndSkinService, HeroAndSkinManager>();
        //#endregion


        //#region Item

        //services.AddScoped<IItemSetService, ItemSetManager>();
        //services.AddScoped<IItemSetStatService, ItemSetStatManager>(); 
        //services.AddScoped<IItemService, ItemManager>();
        //services.AddScoped<IConditionService, ConditionManager>();
        //services.AddScoped<ITriggerService, TriggerManager>();
        //services.AddScoped<IEndOfMatchInventoryService, EndOfMatchInventoryManager>();
        //services.AddScoped<IEndOfMatchInventoryAndItemService, EndOfMatchInventoryAndItemManager>();
        //services.AddScoped<IQualityEffectService, QualityEffectManager>();
        //services.AddScoped<IQualityService, QualityManager>();
        //#endregion


        //#region WebSite
          
        //services.AddScoped<IOpenPositionService, OpenPositionManager>(); 
        //services.AddScoped<IContactUsService, ContactUsManager>(); 
        //services.AddScoped<IEmployeeApplicationService, EmployeeApplicationManager>();  
        //services.AddScoped<IOurGameService, OurGameManager>();  
        //services.AddScoped<IGetInTouchService, GetInTouchManager>(); 
        //services.AddScoped<IGameCategoryService, GameCategoryManager>(); 
        //#endregion


        //#region Product

        //services.AddScoped<IOrderService, OrderManager>();
        //services.AddScoped<IBasketService, BasketManager>();
        //services.AddScoped<IBasketItemService, BasketItemManager>();
        //services.AddScoped<IBasketAndProductService, BasketAndProductManager>();
        //services.AddScoped<IProductService, ProductManager>();
        //services.AddScoped<IProductCategoryService, ProductCategoryManager>();
        //#endregion


        //#region Subscription

        //services.AddScoped<ISubscriptionService, SubscriptionManager>();
        //#endregion 


        //#region Employee 
        //services.AddScoped<ITeamService, TeamManager>(); 
        //services.AddScoped<ITeamAndEmployeeService, TeamAndEmployeeManager>();
        //services.AddScoped<IEmployeeService, EmployeeManager>();
        //#endregion 

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
