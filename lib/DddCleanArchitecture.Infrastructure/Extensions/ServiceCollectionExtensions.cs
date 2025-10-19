using DddCleanArchitecture.Infrastructure.Database;
using DddCleanArchitecture.Infrastructure.Database.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyDbContext(this IServiceCollection services, Action<IServiceProvider, DbContextOptionsBuilder>? configure = null) =>
        services.AddDbContextFactory<MyDbContext>((sp, o) => configure?.Invoke(sp, o))
            .AddSingleton<ISeeder, ArticleSeeder>();
}