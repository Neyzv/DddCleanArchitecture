using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DddCleanArchitecture.Domain.Enums;
using DddCleanArchitecture.Domain.Services.Internationalisation;
using DddCleanArchitecture.Internationalisation.Resources;
using DddCleanArchitecture.Services.Animations;
using DddCleanArchitecture.Services.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

public sealed partial class MainWindowViewModel
    : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly INavigationAnimationService _navigationAnimationService;
    private readonly IInternationalisationService _internationalisationService;

    [ObservableProperty] private Control? _current;

#pragma warning disable CA1822
    public string HomeLabel =>
#pragma warning restore CA1822
        Labels.Home;

    public MainWindowViewModel()
    {
        _navigationService = null!;
        _internationalisationService = null!;
    }

    public MainWindowViewModel(INavigationService navigationService,
        INavigationAnimationService navigationAnimationService,
        IInternationalisationService internationalisationService)
    {
        _navigationService = navigationService;
        _navigationAnimationService = navigationAnimationService;
        _internationalisationService = internationalisationService;

        _navigationService.ViewChanged += OnCurrentViewChanged;
        _ = _navigationService.NavigateToAsync<HomeView>();

        _internationalisationService.LanguageChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        OnPropertyChanged(nameof(HomeLabel));
    }

    private void OnCurrentViewChanged(Control newView) =>
        _navigationAnimationService.SwitchViewAsync(Current, newView, c => Current = c);

    [RelayCommand]
    private Task<HomeView> NavigateToHomeAsync() =>
        _navigationService.NavigateToAsync<HomeView>();

    [RelayCommand]
    private void ChangeLanguageToFrench() =>
        _internationalisationService.TryChangeLanguage(Language.French);

    [RelayCommand]
    private void ChangeLanguageToEnglish() =>
        _internationalisationService.TryChangeLanguage(Language.English);
}