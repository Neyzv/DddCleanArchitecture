using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(ArticleView))]
public sealed partial class ArticleViewModel
    : NavigableViewModel
{
}