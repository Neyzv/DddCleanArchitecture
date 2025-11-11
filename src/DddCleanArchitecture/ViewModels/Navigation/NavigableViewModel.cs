namespace DddCleanArchitecture.ViewModels.Navigation;

public abstract class NavigableViewModel
{
    public virtual Task OnNavigatedFromAsync() =>
        Task.CompletedTask;

    public virtual Task OnNavigateToAsync() =>
        Task.CompletedTask;
}