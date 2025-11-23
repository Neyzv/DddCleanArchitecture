using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.Infrastructure.Database;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;
using DddCleanArchitecture.Infrastructure.Database.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the infrastructure layer to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The application <see cref="IServiceCollection"/>.</param>
    /// <param name="configure">An action to configure the database usage.</param>
    /// <returns></returns>
    public static IServiceCollection AddMyDbContext(this IServiceCollection services, Action<IServiceProvider, DbContextOptionsBuilder>? configure = null) =>
        services.AddDbContextFactory<MyDbContext>((sp, o) => configure?.Invoke(sp, o))
            .AddSingleton<ISeeder, ArticleSeeder>()
            .AddSingleton<IArticleRepository, ArticleRepository>()
            .AddSingleton<ByDateOrderedDescSpecification>()
            .AddSingleton<CommentsIncludeSpecification>();
}