using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles;

public sealed class ArticleRepository
    : EntityRepository<Article>
{
    private readonly IServiceProvider _serviceProvider;

    public ArticleRepository(IDbContextFactory<MyDbContext> dbContextFactory, IServiceProvider serviceProvider)
        : base(dbContextFactory)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<List<Article>> GetAllArticlesOrderedDescByDate() =>
        GetAllAsync(_serviceProvider.GetRequiredService<ByDateOrderedDescSpecification>());

    public Task<Article?> GetArticleByIdWithComments(int id) =>
        GetAsync(
            new GetByIdCriteriaSpecification(id),
            _serviceProvider.GetRequiredService<CommentsIncludeSpecification>()
        );
}