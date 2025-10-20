using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Includes;

public sealed class CommentsIncludeSpecification
    : IIncludeSpecification<Article>
{
    public Expression<Func<Article, object>> Include =>
        x => x.Comments;
}