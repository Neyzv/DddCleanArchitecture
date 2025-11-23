namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class ArticleEntity
    : IDbEntity
{
    /// <summary>
    /// The unique identifier of the article.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The title of the article.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The content of the article.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// The publication date of the article.
    /// </summary>
    public DateTime PublishDate { get; set; }

    /// <summary>
    /// The collection of the article's comments.
    /// </summary>
    public ICollection<CommentEntity> Comments { get; set; } = [];
}