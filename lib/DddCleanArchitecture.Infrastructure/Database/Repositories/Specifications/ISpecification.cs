using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

public interface ISpecification<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    
}