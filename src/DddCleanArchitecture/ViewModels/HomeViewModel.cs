using System.Collections.ObjectModel;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.Internationalisation.Resources;
using DddCleanArchitecture.Models.Articles;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(HomeView))]
public sealed partial class HomeViewModel
    : NavigableViewModel
{
    private readonly IArticleRepository _articleRepository;

    public string CommentsLabel =>
        Labels.Comments;

    public ObservableCollection<ArticlePresenter> Articles { get; } = [];

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
            Articles.Add(new ArticlePresenter(article));
    }
}