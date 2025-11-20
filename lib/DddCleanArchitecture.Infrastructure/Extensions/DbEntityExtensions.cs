using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Extensions;

public static class DbEntityExtensions
{
    public static Article MapToArticle(this ArticleEntity articleEntity) =>
        new()
        {
            Id = articleEntity.Id,
            Title = articleEntity.Title,
            Content = articleEntity.Content,
            PublishDate = articleEntity.PublishDate,
            Comments = articleEntity.Comments.Select(x => x.MapToComment()).ToList()
        };

    private static Comment MapToComment(this CommentEntity commentEntity) =>
        new()
        {
            Id = commentEntity.Id,
            Content = commentEntity.Content,
            CreatedOn = commentEntity.CreatedOn
        };
}