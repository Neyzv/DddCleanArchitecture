using System.Windows.Controls;

namespace DddCleanArchitecture.Services.Navigation;

public delegate void ViewChangedEventHandler(Control newView);

public interface INavigationService
{
    event ViewChangedEventHandler? ViewChanged;

    public void NavigateTo<TView>() where TView : Control;
}