using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using DddCleanArchitecture.Internationalisation.Resources;
using DddCleanArchitecture.Services.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

public sealed partial class MainWindowViewModel
    : ObservableObject
{
    private readonly INavigationService _navigationService;

    [ObservableProperty] private string _homeLabel = Labels.Home;
    [ObservableProperty] private Control? _current;

    public MainWindowViewModel()
    {
        _navigationService = null!;
    }

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        _navigationService.ViewChanged += OnCurrentViewChanged;
        _navigationService.NavigateTo<HomeView>();
    }

    private void OnCurrentViewChanged(Control newView)
    {
        Current = newView;
    }
}