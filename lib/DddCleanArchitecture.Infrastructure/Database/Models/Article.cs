using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Infrastructure.Database.Models;

public sealed class Article
    : ArticleDto, IDbEntity
{
    public int Id { get; set; }

    public new ICollection<Comment> Comments { get; set; } = [];
}