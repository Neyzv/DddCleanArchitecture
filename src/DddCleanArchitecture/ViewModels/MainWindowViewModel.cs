using CommunityToolkit.Mvvm.ComponentModel;

namespace DddCleanArchitecture.ViewModels;

public sealed partial class MainWindowViewModel
    : ObservableObject
{
    [ObservableProperty] private string _greetings = "Hello from DDD architecture !";
}