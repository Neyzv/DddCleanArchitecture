using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;
using DddCleanArchitecture.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Article = DddCleanArchitecture.Domain.Models.Articles.Article;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles;

public sealed class ArticleRepository(IDbContextFactory<MyDbContext> dbContextFactory, IServiceProvider serviceProvider)
    : EntityRepository<ArticleEntity>(dbContextFactory), IArticleRepository
{
    public async Task<IEnumerable<Article>> GetAllArticlesOrderedDescByDate() =>
        (await GetAllAsync(serviceProvider.GetRequiredService<ByDateOrderedDescSpecification>(),
            serviceProvider.GetRequiredService<CommentsIncludeSpecification>()).ConfigureAwait(false))
        .Select(static Article (x) => x.MapToArticle());

    public async Task<Article?> GetArticleByIdWithComments(int id) =>
        (await GetAsync(
            new GetByIdCriteriaSpecification(id),
            serviceProvider.GetRequiredService<CommentsIncludeSpecification>()
        ).ConfigureAwait(false))?.MapToArticle();
}