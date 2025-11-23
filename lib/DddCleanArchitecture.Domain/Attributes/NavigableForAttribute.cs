namespace DddCleanArchitecture.Domain.Attributes;

/// <summary>
/// Attribute to register a navigable view directly on a view model.
/// </summary>
/// <param name="viewType">The type of the navigable view element.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class NavigableForAttribute(Type viewType) : Attribute
{
    /// <summary>
    /// The type of the navigable view element.
    /// </summary>
    public Type ViewType { get; } = viewType;
}