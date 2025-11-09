using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories;

public abstract class EntityRepository<TDbEntity>(IDbContextFactory<MyDbContext> dbContextFactory)
    where TDbEntity : class, IDbEntity
{
    public async Task<TDbEntity?> GetByIdAsync(int id)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
            .ConfigureAwait(false);
    }

    public async Task<List<TDbEntity>> GetAllAsync()
    {
        await using var context = await dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }

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