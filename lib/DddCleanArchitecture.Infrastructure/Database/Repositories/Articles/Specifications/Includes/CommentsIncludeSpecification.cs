using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;

/// <summary>
/// Include specification to load article's comments.
/// </summary>
public sealed class CommentsIncludeSpecification
    : IIncludeSpecification<ArticleEntity>
{
    public Expression<Func<ArticleEntity, object>> Include =>
        x => x.Comments;
}