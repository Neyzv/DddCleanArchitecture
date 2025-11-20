using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Domain.Repositories.Articles;
using DddCleanArchitecture.Domain.Services.Internationalisation;
using DddCleanArchitecture.Internationalisation.Resources;
using DddCleanArchitecture.Models.Articles;
using DddCleanArchitecture.Services.Navigation;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(HomeView))]
public sealed partial class HomeViewModel
    : NavigableViewModel
{
    private readonly IArticleRepository _articleRepository;
    private readonly IInternationalisationService _internationalisationService;
    private readonly INavigationService _navigationService;

#pragma warning disable CA1822
    public string CommentsLabel =>
#pragma warning restore CA1822
        Labels.Comments;

    public ObservableCollection<ArticlePresenter> Articles { get; } = [];

    public HomeViewModel()
    {
        _articleRepository = null!;
        _internationalisationService = null!;
        _navigationService = null!;
    }

    public HomeViewModel(IArticleRepository articleRepository,
        IInternationalisationService internationalisationService,
        INavigationService navigationService)
    {
        _articleRepository = articleRepository;
        _internationalisationService = internationalisationService;
        _navigationService = navigationService;
    }

    private void OnLanguageChanged()
    {
        OnPropertyChanged(nameof(CommentsLabel));
    }

    public override async Task OnNavigateToAsync()
    {
        _internationalisationService.LanguageChanged += OnLanguageChanged;

        Articles.Clear();

        foreach (var article in await _articleRepository.GetAllArticlesOrderedDescByDate())
            Articles.Add(new ArticlePresenter(article));
    }

    public override Task OnNavigatedFromAsync()
    {
        _internationalisationService.LanguageChanged -= OnLanguageChanged;

        return base.OnNavigatedFromAsync();
    }

    [RelayCommand]
    private async Task NavigateToArticleAsync(ArticlePresenter article)
    {
        await _navigationService.NavigateToAsync<ArticleView>();
    }
}