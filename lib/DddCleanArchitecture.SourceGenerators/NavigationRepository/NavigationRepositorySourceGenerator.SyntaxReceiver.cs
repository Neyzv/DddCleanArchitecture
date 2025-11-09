using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using DddCleanArchitecture.SourceGenerators.NavigationRepository.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DddCleanArchitecture.SourceGenerators.NavigationRepository;

public sealed partial class NavigationRepositorySourceGenerator
{
    private const string NavigableViewModel = "NavigableViewModel";
    private const string NavigableForName = "NavigableFor";
    private const string NavigableForAttributeName = "NavigableForAttribute";

    private static bool Predicate(SyntaxNode node, CancellationToken ct)
    {
        if (node is not ClassDeclarationSyntax classSyntax)
            return false;

        if (classSyntax.BaseList is null)
            return false;

        if (!classSyntax
                .AttributeLists
                .SelectMany(static x => x.Attributes)
                .Any(static attribute => attribute.Name.ToString() == NavigableForName))
            return false;

        return classSyntax
            .BaseList
            .Types
            .Select(static x => x.Type)
            .Any(static x => x.ToString().Contains(NavigableViewModel));
    }

    private static NavigableViewInformation Transform(GeneratorSyntaxContext ctx, CancellationToken ct)
    {
        if (ctx.SemanticModel.GetDeclaredSymbol(ctx.Node) is not INamedTypeSymbol symbol)
            throw new Exception("Can not get declared symbol.");

        var attr = symbol
            .GetAttributes()
            .Where(x => x.AttributeClass?.Name.ToString() == NavigableForAttributeName)
            .Select(x => x.ConstructorArguments.First().Value)
            .OfType<INamedTypeSymbol>()
            .Select(static x => x.ToDisplayString())
            .ToImmutableArray();

        if (attr.IsEmpty)
            throw new Exception("Can not get empty attribute list.");

        return new NavigableViewInformation(attr, symbol.ToDisplayString());
    }
}