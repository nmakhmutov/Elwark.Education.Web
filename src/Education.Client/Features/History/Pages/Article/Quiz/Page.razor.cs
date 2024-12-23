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
    private readonly IHistoryArticleClient _articleClient;
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly List<string> _requiredQuizzes = [];
    private readonly ISnackbar _snackbar;
    private readonly ILocalStorageService _storage;
    private ApiResult<ArticleQuizBuilderModel> _response = ApiResult<ArticleQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryArticleClient articleClient,
        IHistoryLearnerClient learnerClient,
        NavigationManager navigation,
        ISnackbar snackbar,
        ILocalStorageService storage
    )
    {
        _localizer = localizer;
        _articleClient = articleClient;
        _learnerClient = learnerClient;
        _navigation = navigation;
        _snackbar = snackbar;
        _storage = storage;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["Articles_Title"], HistoryUrl.Content.Articles()),
            new BreadcrumbItem(_localizer["Quizzes_Title"], null, true)
        ];
    }

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _settings = await _storage.GetItemAsync<QuizSettings>(HistoryLocalStorageKey.QuizSettings) ?? _settings;
        _response = await _articleClient.GetQuizBuilderAsync(Id);
        _response.Match(
            x =>
            {
                foreach (var quiz in x.Quizzes)
                {
                    switch (quiz.Difficulty)
                    {
                        case DifficultyType.Easy when (x.Activity?.IsEasyQuizCompleted ?? false) == false:
                        case DifficultyType.Hard when (x.Activity?.IsHardQuizCompleted ?? false) == false:
                        case DifficultyType.Expert when (x.Activity?.IsExpertQuizCompleted ?? false) == false:
                            _requiredQuizzes.Add($"<b>\"{_localizer.GetQuizDifficultyTitle(quiz.Difficulty)}\"</b>");
                            break;
                    }
                }
            },
            e =>
            {
                if (e.IsQuizAlreadyCreated(out var id))
                    _navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
            }
        );
    }

    private async Task CreateQuizAsync(DifficultyType difficulty)
    {
        var quiz = await _articleClient.CreateQuizAsync(Id, new CreateQuizRequest(difficulty));
        quiz.Match(
            x => _navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
            e => _snackbar.Add(e.UiMessage, Severity.Error)
        );
    }
}
