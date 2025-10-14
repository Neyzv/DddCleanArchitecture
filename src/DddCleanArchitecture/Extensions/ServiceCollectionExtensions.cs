using DddCleanArchitecture.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddSingleton<MainWindowViewModel>()    
            .AddSingleton<MainWindow>(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainWindowViewModel>()
            });
}