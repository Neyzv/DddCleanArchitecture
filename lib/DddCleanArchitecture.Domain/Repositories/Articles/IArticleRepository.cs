using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Domain.Repositories.Articles;

public interface IArticleRepository
{
    /// <summary>
    /// Get all articles ordered by must recent date.
    /// </summary>
    /// <returns>A collection of <see cref="ArticleDto"/>.</returns>
    Task<IEnumerable<ArticleDto>> GetAllArticlesOrderedDescByDate();

    /// <summary>
    /// Get an article by its id with its comments.
    /// </summary>
    /// <param name="id">The id of the desired <see cref="ArticleDto"/>.</param>
    /// <returns>The instance of the <see cref="ArticleDto"/> if it succeed, otherwise <c>null</c>.</returns>
    Task<ArticleDto?> GetArticleByIdWithComments(int id);
}