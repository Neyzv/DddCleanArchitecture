using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

public interface IOrderedSpecification<TDbEntity>
    : ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    /// <summary>
    /// Expression to specify the property to order on.
    /// </summary>
    Expression<Func<TDbEntity, object>> OrderBy { get; }
}