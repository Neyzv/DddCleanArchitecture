using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles;

public sealed class ArticleRepository(IDbContextFactory<MyDbContext> dbContextFactory, IServiceProvider serviceProvider)
    : EntityRepository<Article>(dbContextFactory), IArticleRepository
{
    public async Task<IEnumerable<ArticleDto>> GetAllArticlesOrderedDescByDate() =>
        (await GetAllAsync(serviceProvider.GetRequiredService<ByDateOrderedDescSpecification>()).ConfigureAwait(false))
        .Select(ArticleDto (x) => x);

    public async Task<ArticleDto?> GetArticleByIdWithComments(int id) =>
        await GetAsync(
            new GetByIdCriteriaSpecification(id),
            serviceProvider.GetRequiredService<CommentsIncludeSpecification>()
        ).ConfigureAwait(false);
}