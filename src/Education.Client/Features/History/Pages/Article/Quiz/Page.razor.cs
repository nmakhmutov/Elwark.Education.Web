using Blazored.LocalStorage;
using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Settings;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Article.Quiz;

public sealed partial class Page : ComponentBase
{
    private readonly List<string> _requiredQuizzes = [];
    private ApiResult<ArticleQuizBuilderModel> _response = ApiResult<ArticleQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryArticleClient ArticleClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Articles_Title"], HistoryUrl.Content.Articles()),
        new BreadcrumbItem(L["Quizzes_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _settings = await Storage.GetItemAsync<QuizSettings>(HistoryLocalStorageKey.QuizSettings) ?? _settings;
        _response = await ArticleClient.GetQuizBuilderAsync(Id);
        _response.Match(
            x =>
            {
                foreach (var quiz in x.Quizzes)
                {
                    switch (quiz.Difficulty)
                    {
                        case DifficultyType.Easy when (x.Activity?.IsEasyQuizCompleted ?? false) == false:
                        case DifficultyType.Hard when (x.Activity?.IsHardQuizCompleted ?? false) == false:
                            _requiredQuizzes.Add($"<b>\"{L.GetQuizDifficultyTitle(quiz.Difficulty)}\"</b>");
                            break;
                    }
                }
            },
            e =>
            {
                if (e.IsQuizAlreadyCreated(out var id))
                    Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
            }
        );
    }

    private async Task CreateQuizAsync(DifficultyType difficulty)
    {
        var quiz = await ArticleClient.CreateQuizAsync(Id, new CreateQuizRequest(difficulty));
        quiz.Match(
            x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );
    }
}
