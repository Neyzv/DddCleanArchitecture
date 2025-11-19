namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class ArticleEntity
    : IDbEntity
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public List<CommentEntity> Comments { get; set; } = [];
}