using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DddCleanArchitecture.Enums;
using DddCleanArchitecture.Models.Animations;

namespace DddCleanArchitecture.Factories.Animations;

public static class AnimationFactory
{
    /// <summary>
    /// Create a <see cref="Storyboard"/> instance based on specified <paramref name="animationInformation"/>.
    /// </summary>
    /// <param name="animationInformation">The information of the animation needed.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static Storyboard CreateAnimation(AnimationInformation animationInformation) =>
        animationInformation.AnimationType switch
        {
            AnimationType.FadeIn => CreateFade(false, new Duration(animationInformation.Duration)),
            AnimationType.FadeOut => CreateFade(true, new Duration(animationInformation.Duration)),
            _ => throw new InvalidOperationException()
        };

    /// <summary>
    /// Create a fade animation.
    /// </summary>
    /// <param name="fadeOut"><c>true</c> if fade out effect is needed, otherwise it will be a fade in.</param>
    /// <param name="duration">The duration of the animation.</param>
    /// <returns></returns>
    private static Storyboard CreateFade(bool fadeOut, Duration duration)
    {
        var (from, to) = fadeOut ? (1d, 0d) : (0d, 1d);

        return CreateStoryboard(
            new DoubleAnimation(from, to, duration) { EasingFunction = new QuadraticEase() },
            new PropertyPath(nameof(Control.Opacity)));
    }

    /// <summary>
    /// Create a storyboard.
    /// </summary>
    /// <param name="animation">The double animation.</param>
    /// <param name="path">Path of the property targeted.</param>
    /// <returns></returns>
    private static Storyboard CreateStoryboard(DoubleAnimation animation, PropertyPath path)
    {
        var sb = new Storyboard();

        Storyboard.SetTargetProperty(animation, path);
        sb.Children.Add(animation);

        return sb;
    }
}