using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(HomeView))]
public sealed class HomeViewModel
    : NavigableViewModel
{
}