using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class ArticleEntity
    : Article, IDbEntity
{
    public int Id { get; set; }
    
    public new ICollection<CommentEntity> Comments { get; set; } = [];
}