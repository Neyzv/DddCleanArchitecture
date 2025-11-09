namespace DddCleanArchitecture.ViewModels.Navigation;

public abstract class NavigableViewModel
{
    public virtual void OnNavigatedFrom()
    {
    }

    public virtual void OnNavigateTo()
    {
    }
}