namespace DddCleanArchitecture.Models.Configuration;

public sealed class DatabaseConfiguration
{
    public required string DatabaseName { get; set; }

    public required string ConnectionString { get; set; }
}