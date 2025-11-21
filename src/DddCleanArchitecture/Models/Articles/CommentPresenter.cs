using System.Windows.Media;

namespace DddCleanArchitecture.Models.Articles;

public sealed record CommentPresenter(string Content, DateTime CreatedOn)
{
    public SolidColorBrush IllusColor { get; } =
        new(Color.FromRgb((byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255), (byte)Random.Shared.Next(0, 255)));
}