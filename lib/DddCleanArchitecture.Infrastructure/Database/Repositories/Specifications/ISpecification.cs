using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

/// <summary>
/// Base class for all kinds of specifications.
/// </summary>
/// <typeparam name="TDbEntity">The type of the <see cref="IDbEntity"/>.</typeparam>
public interface ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
}