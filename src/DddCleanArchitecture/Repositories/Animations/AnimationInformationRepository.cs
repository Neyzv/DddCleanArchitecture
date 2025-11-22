using DddCleanArchitecture.Enums;
using DddCleanArchitecture.Models.Animations;

namespace DddCleanArchitecture.Repositories.Animations;

public static class AnimationInformationRepository
{
    /// <summary>
    /// Preset for the "fade in" animation effect.
    /// </summary>
    public static AnimationInformation FadeIn { get; } =
        new AnimationInformation(AnimationType.FadeIn, TimeSpan.FromMilliseconds(150));

    /// <summary>
    /// Preset for the "fade out" animation effect.
    /// </summary>
    public static AnimationInformation FadeOut { get; } =
        new AnimationInformation(AnimationType.FadeOut, TimeSpan.FromMilliseconds(150));
}