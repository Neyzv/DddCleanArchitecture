namespace DddCleanArchitecture.Domain.Models.Articles;

public class Article
{
    /// <summary>
    /// The unique identifier of the article.
    /// </summary>
    public required int Id { get; init; }

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
    /// A collection of the article's comments.
    /// </summary>
    public List<Comment> Comments { get; set; } = [];
}