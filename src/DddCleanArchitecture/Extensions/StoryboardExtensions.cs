using System.Windows;
using System.Windows.Media.Animation;

namespace DddCleanArchitecture.Extensions;

public static class StoryboardExtensions
{
    /// <summary>
    /// Execute a <see cref="Storyboard"/> asynchronously.
    /// </summary>
    /// <param name="storyboard">The storyboard that needs to be executed.</param>
    /// <param name="target">The element to execute on.</param>
    /// <returns></returns>
    public static Task BeginAsync(this Storyboard storyboard, FrameworkElement target)
    {
        var tcs = new TaskCompletionSource();

        storyboard.Completed += OnCompleted;
        storyboard.Begin(target);

        return tcs.Task;

        void OnCompleted(object? sender, EventArgs e)
        {
            storyboard.Completed -= OnCompleted;
            tcs.SetResult();
        }
    }
}