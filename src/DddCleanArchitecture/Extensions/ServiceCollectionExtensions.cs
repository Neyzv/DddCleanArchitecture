using DddCleanArchitecture.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Extensions;

public static class ServiceCollectionExtensions
{
    private const string AppSettingsFile = "appsettings.json";
    private const string AppSettingsDebugFile = "appsettings.Debug.json";
    
    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddSingleton<MainWindowViewModel>()    
            .AddSingleton<MainWindow>(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainWindowViewModel>()
            });

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
            .AddSingleton<IConfiguration>(config);
    }

    public static IServiceCollection AddServicesAndConfiguration(this IServiceCollection services) =>
        services
            .AddServices()
            .AddConfiguration();
}