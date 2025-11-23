namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class CommentEntity
    : IDbEntity
{
    /// <summary>
    /// The unique identifier of the comment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The content of the comment.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// The creation date of the comment.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The unique identifier of the article which this comment is linked to.
    /// </summary>
    public int ArticleId { get; set; }
}