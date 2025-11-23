namespace DddCleanArchitecture.Models.Configuration;

public sealed class DatabaseConfiguration
{
    /// <summary>
    /// The name of the database.
    /// </summary>
    public required string DatabaseName { get; set; }

    /// <summary>
    /// The connection string of the database.
    /// </summary>
    public required string ConnectionString { get; set; }
}