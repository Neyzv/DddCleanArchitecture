using System.Collections.ObjectModel;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(HomeView))]
public sealed partial class HomeViewModel
    : NavigableViewModel
{
    private readonly IArticleRepository _articleRepository;

    public ObservableCollection<Article> Articles { get; } = [];

    public HomeViewModel()
    {
        _articleRepository = null!;
    }

    public HomeViewModel(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public override async Task OnNavigateToAsync()
    {
        Articles.Clear();

        foreach (var article in await _articleRepository.GetAllArticlesOrderedDescByDate())
            Articles.Add(article);
    }
}