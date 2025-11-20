using CommunityToolkit.Mvvm.ComponentModel;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(ArticleView))]
public sealed partial class ArticleViewModel
    : NavigableViewModel
{
    [ObservableProperty] private Article? _article;
}