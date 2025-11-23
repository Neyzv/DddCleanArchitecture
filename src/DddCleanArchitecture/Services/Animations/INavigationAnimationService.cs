using System.Windows.Controls;

namespace DddCleanArchitecture.Services.Animations;

public interface INavigationAnimationService
{
    /// <summary>
    /// Switch current view while applying transition animations.
    /// </summary>
    /// <param name="previousView">The instance of the currently displayed view.</param>
    /// <param name="nextView">The instance of the view to switch to.</param>
    /// <param name="propertySetterCallback">Callback to set the new value to the observable property.</param>
    /// <returns></returns>
    Task SwitchViewAsync(Control? previousView, Control nextView, Action<Control> propertySetterCallback);
}