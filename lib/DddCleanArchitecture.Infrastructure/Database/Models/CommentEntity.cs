namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class CommentEntity
    : IDbEntity
{
    public int Id { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ArticleId { get; set; }
}