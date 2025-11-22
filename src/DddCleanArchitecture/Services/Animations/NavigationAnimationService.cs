using System.Windows.Controls;
using DddCleanArchitecture.Extensions;
using DddCleanArchitecture.Factories.Animations;
using DddCleanArchitecture.ViewModels.Navigation;

namespace DddCleanArchitecture.Services.Animations;

public sealed class NavigationAnimationService
    : INavigationAnimationService
{
    public async Task SwitchViewAsync(Control? previousView, Control nextView, Action<Control> propertySetterCallback)
    {
        if (previousView?.DataContext is NavigableViewModel { ExitAnimation: not null } previousNavigableViewModel)
        {
            await AnimationFactory
                .CreateAnimation(previousNavigableViewModel.ExitAnimation)
                .BeginAsync(previousView);
        }

        propertySetterCallback.Invoke(nextView);

        if (nextView.DataContext is not NavigableViewModel { EnterAnimation: not null } nextNavigableViewModel)
            return;

        await AnimationFactory
            .CreateAnimation(nextNavigableViewModel.EnterAnimation)
            .BeginAsync(nextView);
    }
}