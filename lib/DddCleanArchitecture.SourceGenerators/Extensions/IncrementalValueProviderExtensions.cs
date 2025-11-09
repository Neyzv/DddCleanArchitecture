using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace DddCleanArchitecture.SourceGenerators.Extensions;

public static class IncrementalValueProviderExtensions
{
    public static IncrementalValuesProvider<TValue> CreateCompiledNamedSymbolsProvider<TValue>(
        this IncrementalValueProvider<Compilation> provider,
        Func<INamedTypeSymbol, bool> predicate,
        Func<INamedTypeSymbol, CancellationToken, TValue> transform
    ) =>
        provider
            .SelectMany(GetCompiledSymbols)
            .Where(predicate)
            .Select(transform);

    private static IEnumerable<INamedTypeSymbol> GetCompiledSymbols(Compilation compilation, CancellationToken token)
    {
        if (token.IsCancellationRequested)
            yield break;

        var namespaces = new Queue<INamespaceSymbol>();

        foreach (var referencedAsm in compilation.SourceModule.ReferencedAssemblySymbols
                     .Where(static x => x.Identity.HasPublicKey)) // Used to avoid public references such as nuget dependencies
            namespaces.Enqueue(referencedAsm.GlobalNamespace);

        while (namespaces.Count > 0)
        {
            var currentNamespace = namespaces.Dequeue();

            var types = new Queue<INamedTypeSymbol>();

            foreach (var type in currentNamespace.GetTypeMembers())
                types.Enqueue(type);

            while (types.Count > 0)
            {
                var currentType = types.Dequeue();

                yield return currentType;

                foreach (var nestedType in currentType.GetTypeMembers())
                    types.Enqueue(nestedType);
            }

            foreach (var nestedNamespace in currentNamespace.GetNamespaceMembers())
                namespaces.Enqueue(nestedNamespace);
        }
    }
}