namespace DddCleanArchitecture.Infrastructure.Database.Models;

/// <summary>
/// Interface for database registered entities.
/// </summary>
public interface IDbEntity
{
    /// <summary>
    /// The unique identifier of this database entity.
    /// </summary>
    int Id { get; }
}