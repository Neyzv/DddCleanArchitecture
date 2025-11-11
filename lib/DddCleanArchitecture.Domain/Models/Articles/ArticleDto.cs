namespace DddCleanArchitecture.Domain.Models.Articles;

public class ArticleDto
{
    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public ICollection<CommentDto> Comments { get; set; } = [];
}