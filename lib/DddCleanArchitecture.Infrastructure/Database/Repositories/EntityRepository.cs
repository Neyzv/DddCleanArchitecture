using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories;

public class EntityRepository<TDbEntity>
    where TDbEntity : class, IDbEntity
{
    private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

    public EntityRepository(IDbContextFactory<MyDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<TDbEntity?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
        
        return await context
            .Set<TDbEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
            .ConfigureAwait(false);
    }

    public async Task<List<TDbEntity>> GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
        
        return await context.Set<TDbEntity>().ToListAsync();
    }

    protected async Task<List<TDbEntity>> GetAllAsync(params IEnumerable<ISpecification<TDbEntity>> specifications)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);

        return await context
            .Set<TDbEntity>()
            .GetQuery(specifications)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}