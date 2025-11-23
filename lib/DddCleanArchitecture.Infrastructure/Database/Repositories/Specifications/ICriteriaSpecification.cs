using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

public interface ICriteriaSpecification<TDbEntity>
    : ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    /// <summary>
    /// Expression to specify the criteria to retrieve an instance of the model.
    /// </summary>
    Expression<Func<TDbEntity, bool>> Criteria { get; }
}