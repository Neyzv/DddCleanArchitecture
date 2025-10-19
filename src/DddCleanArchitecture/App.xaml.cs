using System.Windows;
using DddCleanArchitecture.Extensions;
using DddCleanArchitecture.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceProvider = new ServiceCollection()
            .AddServicesAndConfiguration()
            .BuildServiceProvider();

        var context = ServiceProvider.GetRequiredService<IDbContextFactory<MyDbContext>>().CreateDbContext();
        context.Database.Migrate();

        MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}