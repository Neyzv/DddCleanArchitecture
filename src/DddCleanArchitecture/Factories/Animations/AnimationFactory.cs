using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DddCleanArchitecture.Enums;
using DddCleanArchitecture.Models.Animations;

namespace DddCleanArchitecture.Factories.Animations;

public static class AnimationFactory
{
    public static Storyboard CreateAnimation(AnimationInformation animationInformation) =>
        animationInformation.AnimationType switch
        {
            AnimationType.FadeIn => CreateFade(false, new Duration(animationInformation.Duration)),
            AnimationType.FadeOut => CreateFade(true, new Duration(animationInformation.Duration)),
            _ => throw new InvalidOperationException()
        };

    private static Storyboard CreateFade(bool fadeOut, Duration duration)
    {
        var (from, to) = fadeOut ? (1d, 0d) : (0d, 1d);

        return CreateStoryboard(
            new DoubleAnimation(from, to, duration) { EasingFunction = new QuadraticEase() },
            new PropertyPath(nameof(Control.Opacity)));
    }

    private static Storyboard CreateStoryboard(DoubleAnimation animation, PropertyPath path)
    {
        var sb = new Storyboard();

        Storyboard.SetTargetProperty(animation, path);
        sb.Children.Add(animation);

        return sb;
    }
}