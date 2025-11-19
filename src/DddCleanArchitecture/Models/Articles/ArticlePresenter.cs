using System.Windows.Media;
using DddCleanArchitecture.Domain.Models.Articles;

namespace DddCleanArchitecture.Models.Articles;

public sealed class ArticlePresenter(Article article)
{
    public string Title =>
        article.Title;

    public DateTime PublishDate =>
        article.PublishDate;

    public int CommentCount =>
        article.Comments.Count;

    public SolidColorBrush IllusColor { get; } =
        new(Color.FromRgb((byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255)));
}