namespace DddCleanArchitecture.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class NavigableForAttribute(Type viewType) : Attribute
{
    public Type ViewType { get; } = viewType;
}