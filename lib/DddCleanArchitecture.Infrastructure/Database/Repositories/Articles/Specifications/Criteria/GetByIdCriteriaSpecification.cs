using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Criteria;

public class GetByIdCriteriaSpecification
    : ICriteriaSpecification<Article>
{
    private readonly int _id;

    public GetByIdCriteriaSpecification(int id)
    {
        _id = id;
    }

    public Expression<Func<Article, bool>> Criteria =>
        x => x.Id == _id;
}