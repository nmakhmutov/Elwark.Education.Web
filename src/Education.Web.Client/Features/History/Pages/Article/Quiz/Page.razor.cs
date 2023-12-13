using Blazored.LocalStorage;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Article.Model;
using Education.Web.Client.Features.History.Services.Article.Request;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Settings;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Article.Quiz;

public sealed partial class Page
{
    private ApiResult<ArticleQuizBuilderModel> _result = ApiResult<ArticleQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;
    private bool _isLoading;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryArticleService ArticleService { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

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
        _result = await ArticleService.GetQuizBuilderAsync(Id);
        await _result.MatchAsync(x =>
            {
                if (x.Quizzes.Any(e => e.IsAllowed && e.Type == _settings.Difficulty))
                    return Task.CompletedTask;

                return ChangeDifficulty(x.Quizzes.FirstOrDefault(t => t.IsAllowed)?.Type);
            },
            x =>
            {
                if (x.IsQuizAlreadyCreated(out var id))
                    Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
            });
    }

    private async Task ChangeDifficulty(DifficultyType? difficulty)
    {
        _settings = _settings with { Difficulty = difficulty };
        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }

    private async Task CreateQuizAsync()
    {
        if (!_settings.Difficulty.HasValue)
            return;

        _isLoading = true;

        var quiz = await ArticleService.CreateQuizAsync(Id, new CreateQuizRequest(_settings.Difficulty.Value));
        quiz.Match(
            x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );

        _isLoading = false;
    }
}
