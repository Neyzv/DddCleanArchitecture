using System.Windows.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace DddCleanArchitecture.MarkupExtensions;

public sealed class ResolvedViewModel
    : MarkupExtension
{
    private static readonly Type ObservableObjectType = typeof(ObservableObject);

    public required Type ViewModel { get; set; }

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        if (!ViewModel.IsSubclassOf(ObservableObjectType))
            throw new InvalidOperationException($"'{ViewModel.FullName}' is not a Subclass of '{nameof(ObservableObject)}'.");

        return App.ServiceProvider.GetService(ViewModel)
               ?? ActivatorUtilities.CreateInstance(App.ServiceProvider, ViewModel)
               ?? throw new Exception($"'{ViewModel.FullName}' is not a valid ViewModel.");
    }
}