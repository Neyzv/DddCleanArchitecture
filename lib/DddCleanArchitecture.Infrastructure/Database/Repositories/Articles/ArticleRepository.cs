using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles;

public sealed class ArticleRepository(IDbContextFactory<MyDbContext> dbContextFactory, IServiceProvider serviceProvider) : EntityRepository<Article>(dbContextFactory)
{
    public Task<List<Article>> GetAllArticlesOrderedDescByDate() =>
        GetAllAsync(serviceProvider.GetRequiredService<ByDateOrderedDescSpecification>());

    public Task<Article?> GetArticleByIdWithComments(int id) =>
        GetAsync(
            new GetByIdCriteriaSpecification(id),
            serviceProvider.GetRequiredService<CommentsIncludeSpecification>()
        );
}