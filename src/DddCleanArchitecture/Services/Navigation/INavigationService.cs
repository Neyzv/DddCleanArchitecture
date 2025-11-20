using System.Windows.Controls;

namespace DddCleanArchitecture.Services.Navigation;

/// <summary>
/// Event handler for the navigation system.
/// </summary>
public delegate void ViewChangedEventHandler(Control newView);

public interface INavigationService
{
    /// <summary>
    /// Raised when the current view changed for this instance.
    /// </summary>
    event ViewChangedEventHandler? ViewChanged;

    /// <summary>
    /// Navigate to the specified view while triggering the view model navigation functions.
    /// </summary>
    /// <typeparam name="TView">The type of the desired view</typeparam>
    /// <returns>The instance of the view.</returns>
    Task<TView> NavigateToAsync<TView>()
        where TView : Control;
}