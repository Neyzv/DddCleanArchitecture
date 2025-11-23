using CommunityToolkit.Mvvm.ComponentModel;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Models.Animations;

namespace DddCleanArchitecture.ViewModels.Navigation;

/// <summary>
/// Navigable view model which needs to be used with the <see cref="NavigableForAttribute"/> to be registered in the navigation repository.<br/>
/// <br/>
/// <b>NB:</b> You don't need to register or inject the view model because it will be created as a singleton instance by the repository.
/// </summary>
public abstract class NavigableViewModel
    : ObservableObject
{
    /// <summary>
    /// The <see cref="AnimationInformation"/> when we enter to this view model.
    /// </summary>
    public virtual AnimationInformation? EnterAnimation { get; } = null;

    /// <summary>
    /// The <see cref="AnimationInformation"/> when we exit this view model.
    /// </summary>
    public virtual AnimationInformation? ExitAnimation { get; } = null;

    /// <summary>
    /// Executed before leaving the view associated with this view model.
    /// </summary>
    /// <returns></returns>
    public virtual Task OnNavigatedFromAsync() =>
        Task.CompletedTask;

    /// <summary>
    /// Executed when entering to the view associated with this view model.
    /// </summary>
    /// <returns></returns>
    public virtual Task OnNavigateToAsync() =>
        Task.CompletedTask;
}