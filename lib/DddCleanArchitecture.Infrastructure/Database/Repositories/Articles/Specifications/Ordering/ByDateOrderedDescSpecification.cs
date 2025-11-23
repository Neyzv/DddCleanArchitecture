using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;

/// <summary>
/// Ordering descending specification by publication date for an article.
/// </summary>
public sealed class ByDateOrderedDescSpecification
    : IOrderedDescSpecification<ArticleEntity>
{
    public Expression<Func<ArticleEntity, object>> OrderByDescending =>
        x => x.PublishDate;
}