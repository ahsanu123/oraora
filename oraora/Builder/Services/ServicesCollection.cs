using Oraora.Repository;

namespace Oraora.Builder.Services;

public static class ServicesCollection
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services)
    {
        services.AddSingleton<ISqliteConnectionProvider, SqliteConnectionProvider>();

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
