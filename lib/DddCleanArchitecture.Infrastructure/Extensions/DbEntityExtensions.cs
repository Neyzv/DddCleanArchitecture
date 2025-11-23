using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Infrastructure.Database.Models;

namespace DddCleanArchitecture.Infrastructure.Extensions;

public static class DbEntityExtensions
{
    /// <summary>
    /// Map the article entity to its domain representation.
    /// </summary>
    /// <param name="articleEntity">The article entity that needs to be mapped.</param>
    /// <returns></returns>
    public static Article MapToArticle(this ArticleEntity articleEntity) =>
        new()
        {
            Id = articleEntity.Id,
            Title = articleEntity.Title,
            Content = articleEntity.Content,
            PublishDate = articleEntity.PublishDate,
            Comments = articleEntity.Comments.Select(x => x.MapToComment()).ToList()
        };

    /// <summary>
    /// Map the comment entity to its domain representation.
    /// </summary>
    /// <param name="commentEntity">The comment entity that needs to be mapped.</param>
    /// <returns></returns>
    private static Comment MapToComment(this CommentEntity commentEntity) =>
        new()
        {
            Id = commentEntity.Id,
            Content = commentEntity.Content,
            CreatedOn = commentEntity.CreatedOn
        };
}