using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories;

public interface IEntityRepository<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    
}