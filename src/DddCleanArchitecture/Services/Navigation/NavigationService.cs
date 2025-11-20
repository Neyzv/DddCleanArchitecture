using System.Windows.Controls;
using DddCleanArchitecture.ViewModels.Navigation;

namespace DddCleanArchitecture.Services.Navigation;

public sealed class NavigationService
    : INavigationService
{
    private readonly NavigationRepository _navigationRepository;

    private NavigableViewModel? _currentViewModel;

    public event ViewChangedEventHandler? ViewChanged;

    public NavigationService(NavigationRepository navigationRepository)
    {
        _navigationRepository = navigationRepository;
    }

    public async Task<TView> NavigateToAsync<TView>()
        where TView : Control
    {
        if (_navigationRepository.TryGetView<TView>() is not { } view)
            throw new KeyNotFoundException($"View '{typeof(TView)}' not found.");

        if (view.DataContext is not NavigableViewModel viewModel)
            throw new InvalidOperationException($"View '{typeof(TView)}' data context should be of type '{typeof(NavigableViewModel)}'.");

        if (_currentViewModel is not null)
            await _currentViewModel.OnNavigatedFromAsync().ConfigureAwait(false);

        _currentViewModel = viewModel;

        ViewChanged?.Invoke(view);

        await viewModel.OnNavigateToAsync().ConfigureAwait(false);

        return view;
    }
}