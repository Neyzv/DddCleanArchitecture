using System.Windows.Media;

namespace DddCleanArchitecture.Models.Articles;

public sealed record ArticlePresenter(int Id, string Title, DateTime PublishDate, int CommentCount)
{
    /// <summary>
    /// Randomly generated illus color.
    /// </summary>
    public SolidColorBrush IllusColor { get; } =
        new(Color.FromRgb((byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255)));
}