using Blazored.LocalStorage;
using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Features.History.Clients.Quiz.Request;
using Education.Client.Features.History.Settings;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes;

public sealed partial class Page
{
    private bool _isLoading;
    private ApiResult<EpochQuizBuilderModel> _result = ApiResult<EpochQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryQuizClient QuizClient { get; init; } = default!;

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
        _result = await QuizClient.GetTestBuilderAsync();

        await _result.MatchAsync(x =>
            {
                if (x.Quizzes.Any(e => e.IsAllowed && e.Type == _settings.Difficulty))
                    return Task.CompletedTask;

                return ChangeDifficultyAsync(x.Quizzes.FirstOrDefault(t => t.IsAllowed)?.Type);
            },
            x =>
            {
                if (x.IsQuizAlreadyCreated(out var id))
                    Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
            });
        _result.MathError(x =>
        {
            if (x.IsQuizAlreadyCreated(out var id))
                Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
        });
    }

    private async Task CreateQuizAsync()
    {
        if (!_settings.Difficulty.HasValue)
            return;

        _isLoading = true;

        (await QuizClient.CreateAsync(new CreateQuizRequest(_settings.Difficulty.Value, _settings.Epoch)))
            .Match(
                x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
                e => Snackbar.Add(e.Detail, Severity.Error)
            );

        _isLoading = false;
    }

    private async Task ChangeEpochAsync(EpochType epoch)
    {
        _settings = _settings with { Epoch = epoch };
        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }

    private async Task ChangeDifficultyAsync(DifficultyType? difficulty)
    {
        _settings = _settings with { Difficulty = difficulty };
        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }
}
