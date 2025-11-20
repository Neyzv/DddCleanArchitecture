namespace DddCleanArchitecture.Domain.Models.Articles;

public class Article
{
    public required int Id { get; init; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public List<Comment> Comments { get; set; } = [];
}