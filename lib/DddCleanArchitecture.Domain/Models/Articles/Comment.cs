namespace DddCleanArchitecture.Domain.Models.Articles;

public class Comment
{
    public int Id { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedOn { get; set; }
}