using LearnRazor.Models.Binding;

namespace LearnRazor.Builder;

public static class AddConfigurationProviderBuilder
{
    public static IServiceCollection AddConfigurationProvider(
        this IServiceCollection services,
        IConfigurationRoot configuration
    )
    {
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        return services;
    }
}
