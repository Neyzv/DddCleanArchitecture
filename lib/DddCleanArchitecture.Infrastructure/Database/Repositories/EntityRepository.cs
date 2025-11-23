using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories;

public abstract class EntityRepository<TDbEntity>(IDbContextFactory<MyDbContext> dbContextFactory)
    where TDbEntity : class, IDbEntity
{
    /// <summary>
    /// Retrieve an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns></returns>
    public async Task<TDbEntity?> GetByIdAsync(int id)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieve all instances of an entity without their dependency properties.
    /// </summary>
    /// <returns></returns>
    public async Task<List<TDbEntity>> GetAllAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieve the first instance of an entity which satisfies the specified specifications.
    /// </summary>
    /// <param name="specifications">The specifications that need to be satisfied.</param>
    /// <returns></returns>
    protected async Task<TDbEntity?> GetAsync(params IEnumerable<ISpecification<TDbEntity>> specifications)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .GetQuery(specifications)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Retrieve all instances of an entity which satisfies the specified specifications.
    /// </summary>
    /// <param name="specifications">The specifications that need to be satisfied.</param>
    /// <returns></returns>
    protected async Task<List<TDbEntity>> GetAllAsync(params IEnumerable<ISpecification<TDbEntity>> specifications)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .GetQuery(specifications)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}