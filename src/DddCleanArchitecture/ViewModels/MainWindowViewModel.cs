using CommunityToolkit.Mvvm.ComponentModel;
using DddCleanArchitecture.Internationalisation.Resources;

namespace DddCleanArchitecture.ViewModels;

public sealed partial class MainWindowViewModel
    : ObservableObject
{
    [ObservableProperty] private string _homeLabel = Labels.Home;
}