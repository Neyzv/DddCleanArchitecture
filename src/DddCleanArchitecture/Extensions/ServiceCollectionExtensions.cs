using DddCleanArchitecture.Application.Extensions;
using DddCleanArchitecture.Infrastructure.Extensions;
using DddCleanArchitecture.Models.Configuration;
using DddCleanArchitecture.Services.Animations;
using DddCleanArchitecture.Services.Navigation;
using DddCleanArchitecture.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DddCleanArchitecture.Extensions;

public static class ServiceCollectionExtensions
{
    private const string AppSettingsFile = "appsettings.json";
    private const string AppSettingsDebugFile = "appsettings.Debug.json";

    /// <summary>
    /// Add the app services.
    /// </summary>
    /// <param name="services">The application <see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddMyDbContext((sp, o) =>
            {
                var dbConfig = sp.GetRequiredService<IOptions<DatabaseConfiguration>>().Value;

                o.UseSqlite(string.Format(dbConfig.ConnectionString, dbConfig.DatabaseName));
            })
            .AddApplicationLayer()
            .AddScoped<NavigationRepository>()
            .AddScoped<INavigationService, NavigationService>()
            .AddSingleton<INavigationAnimationService, NavigationAnimationService>()
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<MainWindow>();

    /// <summary>
    /// Add configuration.
    /// </summary>
    /// <param name="services">The application <see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    private static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(AppSettingsFile, optional: false, reloadOnChange: false)
#if DEBUG
            .AddJsonFile(AppSettingsDebugFile, optional: false, reloadOnChange: true)
#endif
            .Build();

        return services
            .AddSingleton<IConfiguration>(config)
            .Configure<DatabaseConfiguration>(config.GetSection(nameof(DatabaseConfiguration)));
    }

    /// <summary>
    /// Add services and configuration for the application.
    /// </summary>
    /// <param name="services">The application <see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    public static IServiceCollection AddServicesAndConfiguration(this IServiceCollection services) =>
        services
            .AddConfiguration()
            .AddServices();
}