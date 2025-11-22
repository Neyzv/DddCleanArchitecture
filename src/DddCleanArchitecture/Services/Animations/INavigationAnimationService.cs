using System.Windows.Controls;

namespace DddCleanArchitecture.Services.Animations;

public interface INavigationAnimationService
{
    Task SwitchViewAsync(Control? previousView, Control nextView, Action<Control> propertySetterCallback);
}