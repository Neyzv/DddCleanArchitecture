namespace DddCleanArchitecture.Domain.Models.Articles;

public class Comment
{
    public required string Content { get; set; }

    public DateTime CreatedOn { get; set; }
}