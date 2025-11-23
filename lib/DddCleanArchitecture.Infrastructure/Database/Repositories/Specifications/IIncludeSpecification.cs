using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

public interface IIncludeSpecification<TDbEntity>
    : ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    /// <summary>
    /// Expression to specify the dependency property that needs to be loaded when retrieving result.
    /// </summary>
    Expression<Func<TDbEntity, object>> Include { get; }
}