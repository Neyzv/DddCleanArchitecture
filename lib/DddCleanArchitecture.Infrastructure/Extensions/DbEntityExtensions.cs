using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Extensions;

public static class DbEntityExtensions
{
    public static Article MapToArticle(this ArticleEntity articleEntity) =>
        new()
        {
            Title = articleEntity.Title,
            Content = articleEntity.Content,
            PublishDate = articleEntity.PublishDate,
            Comments = articleEntity.Comments.Select(x => x.MapToComment()).ToList()
        };

    public static Comment MapToComment(this CommentEntity commentEntity) =>
        new()
        {
            Content = commentEntity.Content,
            CreatedOn = commentEntity.CreatedOn
        };
}