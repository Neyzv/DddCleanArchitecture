using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

public interface IOrderedDescSpecification<TDbEntity>
    : ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    Expression<Func<TDbEntity, object>> OrderByDescending { get; }
}