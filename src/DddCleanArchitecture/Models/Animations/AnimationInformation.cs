using DddCleanArchitecture.Enums;

namespace DddCleanArchitecture.Models.Animations;

public sealed record AnimationInformation(AnimationType AnimationType, TimeSpan Duration);