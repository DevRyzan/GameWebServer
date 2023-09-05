 

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    
    //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    //{
    //    services.AddSingleton<IStorageService,  StorageManager>();
    //    return services;
    //}
    //public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    //{
    //    serviceCollection.AddSingleton<IStorage, T>();
    //}

    //public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
    //{
    //    switch (storageType)
    //    {
    //        case StorageType.Local:
    //            serviceCollection.AddScoped<IStorage, LocalStorage>();
    //            break;
    //        case StorageType.Azure:
    //            serviceCollection.AddScoped<IStorage, AzureStorage>();
    //            break;
    //        case StorageType.AWS:

    //            break;
    //        default:
    //            serviceCollection.AddScoped<IStorage, LocalStorage>();
    //            break;
    //    }
    //}
}
