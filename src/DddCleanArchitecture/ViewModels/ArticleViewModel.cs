using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using DddCleanArchitecture.Domain.Attributes;
using DddCleanArchitecture.Domain.Models.Articles;
using DddCleanArchitecture.Models.Animations;
using DddCleanArchitecture.Models.Articles;
using DddCleanArchitecture.Repositories.Animations;
using DddCleanArchitecture.ViewModels.Navigation;
using DddCleanArchitecture.Views;

namespace DddCleanArchitecture.ViewModels;

[NavigableFor(typeof(ArticleView))]
public sealed partial class ArticleViewModel
    : NavigableViewModel
{
    [ObservableProperty] private Article? _article;

    public ObservableCollection<CommentPresenter> Comments { get; } = [];

    public override AnimationInformation? EnterAnimation =>
        AnimationInformationRepository.FadeIn;

    public override AnimationInformation? ExitAnimation =>
        AnimationInformationRepository.FadeOut;

    partial void OnArticleChanged(Article? value)
    {
        Comments.Clear();

        if (value is null)
            return;

        foreach (var comment in value.Comments.OrderByDescending(static x => x.CreatedOn))
            Comments.Add(new CommentPresenter(comment.Content, comment.CreatedOn));
    }
}