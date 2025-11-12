using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Domain.Repositories.Articles;

public interface IArticleRepository
{
    /// <summary>
    /// Get all articles ordered by must recent date.
    /// </summary>
    /// <returns>A collection of <see cref="Article"/>.</returns>
    Task<IEnumerable<Article>> GetAllArticlesOrderedDescByDate();

    /// <summary>
    /// Get an article by its id with its comments.
    /// </summary>
    /// <param name="id">The id of the desired <see cref="Article"/>.</param>
    /// <returns>The instance of the <see cref="Article"/> if it succeed, otherwise <c>null</c>.</returns>
    Task<Article?> GetArticleByIdWithComments(int id);
}