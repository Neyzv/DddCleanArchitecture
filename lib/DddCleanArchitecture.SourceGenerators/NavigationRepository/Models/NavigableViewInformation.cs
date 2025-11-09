using System.Collections.Immutable;

namespace DddCleanArchitecture.SourceGenerators.NavigationRepository.Models;

public sealed record NavigableViewInformation(ImmutableArray<string> ViewTypesNames, string ViewModelTypeName);