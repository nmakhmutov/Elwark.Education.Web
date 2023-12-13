using Blazored.LocalStorage;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Features.History.Settings;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Quizzes;

public sealed partial class Page
{
    private ApiResult<EpochQuizBuilderModel> _result = ApiResult<EpochQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;
    private bool _isLoading;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryQuizService QuizService { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Quizzes_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _settings = await Storage.GetItemAsync<QuizSettings>(HistoryLocalStorageKey.QuizSettings) ?? _settings;
        _result = await QuizService.GetTestBuilderAsync();

        _result.MathError(x =>
        {
            if (x.IsQuizAlreadyCreated(out var id))
                Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
        });
    }

    private async Task CreateQuizAsync()
    {
        if(!_settings.Difficulty.HasValue)
            return;
        
        _isLoading = true;
        (await QuizService.CreateAsync(new CreateQuizRequest(_settings.Difficulty.Value, _settings.Epoch)))
            .Match(
                x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
                e => Snackbar.Add(e.Detail, Severity.Error)
            );

        _isLoading = false;
    }

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
