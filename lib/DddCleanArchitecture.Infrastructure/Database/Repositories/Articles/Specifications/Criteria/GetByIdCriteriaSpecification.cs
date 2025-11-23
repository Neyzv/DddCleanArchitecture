using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;

/// <summary>
/// Criteria specification to retrieve an article by its identifier.
/// </summary>
/// <param name="id">The unique identifier of the article.</param>
public class GetByIdCriteriaSpecification(int id) : ICriteriaSpecification<ArticleEntity>
{
    public Expression<Func<ArticleEntity, bool>> Criteria =>
        x => x.Id == id;
}