using System.Configuration;
using System.Data;
using System.Windows;
using DddCleanArchitecture.Extensions;
using DddCleanArchitecture.Infrastructure.Database;
using DddCleanArchitecture.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection()
            .AddMyDbContext()
            .AddServicesAndConfiguration()
            .BuildServiceProvider();

        var context = services.GetRequiredService<IDbContextFactory<MyDbContext>>().CreateDbContext();
        context.Database.Migrate();
        
        MainWindow = services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}