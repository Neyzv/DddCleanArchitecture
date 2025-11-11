namespace DddCleanArchitecture.Domain.Models.Articles;

public class CommentDto
{
    public required string Content { get; set; }

    public DateTime CreatedOn { get; set; }
}