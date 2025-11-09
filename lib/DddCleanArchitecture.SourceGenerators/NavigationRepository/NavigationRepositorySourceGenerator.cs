using Microsoft.CodeAnalysis;

namespace DddCleanArchitecture.SourceGenerators.NavigationRepository;

[Generator(LanguageNames.CSharp)]
public sealed partial class NavigationRepositorySourceGenerator
    : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context
            .SyntaxProvider
            .CreateSyntaxProvider(Predicate, Transform)
            .Collect();

        context.RegisterSourceOutput(provider, static (spc, source) => Generate(spc, source));
    }
}