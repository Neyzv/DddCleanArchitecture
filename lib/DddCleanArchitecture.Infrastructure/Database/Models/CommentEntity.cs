using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class CommentEntity
    : Comment, IDbEntity
{
    public int Id { get; set; }

    public int ArticleId { get; set; }
}