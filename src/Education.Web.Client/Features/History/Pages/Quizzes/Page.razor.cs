using Blazored.LocalStorage;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Quizzes;

public sealed partial class Page
{
    private Settings _settings = new(EpochType.None, null);
    private ApiResult<QuizBuilderModel> _result = ApiResult<QuizBuilderModel>.Loading();

    private List<BreadcrumbItem> Breadcrumbs =>
        new()
        {
            new BreadcrumbItem(L["History_Title"], HistoryUrl.Root)
        };

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryQuizService QuizService { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; set; } = default!;

    [SupplyParameterFromQuery(Name = "article")]
    public string? ArticleId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _settings = await Storage.GetItemAsync<Settings>(HistoryLocalStorageKey.QuizSettings) ?? _settings;
        _result = await QuizService.GetTestBuilderAsync(ArticleId);

        _result.MathError(x =>
        {
            if (x.IsQuizAlreadyCreated(out var id))
                Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
        });
    }

    private async Task OnQuizCreateAsync(CreateEpochQuizRequest request) =>
        (await QuizService.CreateAsync(request))
        .Match(
            x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Overview.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );

    private async Task OnQuizCreateAsync(CreateArticleQuizRequest request) =>
        (await QuizService.CreateAsync(request))
        .Match(
            x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Overview.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );

    private async Task OnEpochChanged(EpochType epoch)
    {
        _settings = _settings with { Epoch = epoch };
        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }

    private async Task OnDifficultyChanged(DifficultyType? difficulty)
    {
        _settings = _settings with { Difficulty = difficulty };
        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }
}

public sealed record Settings(EpochType Epoch, DifficultyType? Difficulty);
