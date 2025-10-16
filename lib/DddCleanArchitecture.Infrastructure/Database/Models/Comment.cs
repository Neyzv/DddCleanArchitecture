namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class Comment
    : IDbEntity
{
    public int Id { get; set; }
    
    public required string Content { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public int ArticleId { get; set; }
}