using System.Collections.Immutable;
using DddCleanArchitecture.Infrastructure.Database.Seeding;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database;

public sealed class MyDbContext(DbContextOptions<MyDbContext> options, IEnumerable<ISeeder> seeders) : DbContext(options)
{
    private readonly ImmutableArray<ISeeder> _seeders = [..seeders];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDb.db")
            }.ToString();

            optionsBuilder.UseSqlite(connectionString);
        }

        optionsBuilder
            .UseSeeding(Seed)
            .UseAsyncSeeding(SeedAsync);
    }

    private void Seed(DbContext context, bool migrationApplied)
    {
        foreach (var seeder in _seeders.Where(x => x.ShouldBeApplied(context)))
            seeder.Seed(context);
    }

    private async Task SeedAsync(DbContext context, bool migrationApplied, CancellationToken token)
    {
        var tasks = new List<Task>();

        foreach (var seeder in _seeders)
        {
            if (!await seeder.ShouldBeAppliedAsync(context, token).ConfigureAwait(false))
                continue;

            tasks.Add(seeder.SeedAsync(context, token));
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}