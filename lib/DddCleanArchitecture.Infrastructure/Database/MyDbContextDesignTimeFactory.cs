using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DddCleanArchitecture.Infrastructure.Database;

/// <summary>
/// Class that provides an instance of the <see cref="MyDbContext"/> to execute EF Core commands.
/// </summary>
public sealed class MyDbContextDesignTimeFactory
    : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        return new MyDbContext(new DbContextOptions<MyDbContext>(), []);
    }
}