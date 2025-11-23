namespace DddCleanArchitecture.Domain.Models.Articles;

public class Comment
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
}