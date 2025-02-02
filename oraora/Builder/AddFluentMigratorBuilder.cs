using System.Reflection;
using FluentMigrator.Runner;
using Oraora.Extension;

namespace Oraora.Builder;

public static class BuilderAddFluentMigratorProvider
{
    public static IServiceCollection AddFluentMigratorProvider(
        this IServiceCollection services,
        string connectionString
    )
    {
        services
            .AddFluentMigratorCore()
            .ConfigureRunner(runnerBuilder =>
                runnerBuilder
                    // .AddSQLite()
                    .AddSQLiteWithCompatibilityMode(false, false, CompatibilityMode.LOOSE)
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.GetExecutingAssembly())
                    .For.All()
            )
            // Enable logging to console in the FluentMigrator way
            .AddLogging(loggingBuilder => loggingBuilder.AddFluentMigratorConsole())
            .Configure<FluentMigratorLoggerOptions>(options =>
            {
                options.ShowSql = true;
                options.ShowElapsedTime = true;
            })
            // Build the service provider
            .BuildServiceProvider(false);
        return services;
    }
}
