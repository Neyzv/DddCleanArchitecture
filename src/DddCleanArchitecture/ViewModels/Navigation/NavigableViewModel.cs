using CommunityToolkit.Mvvm.ComponentModel;

namespace DddCleanArchitecture.ViewModels.Navigation;

public abstract class NavigableViewModel
    : ObservableObject
{
    public virtual Task OnNavigatedFromAsync() =>
        Task.CompletedTask;

    public virtual Task OnNavigateToAsync() =>
        Task.CompletedTask;
}