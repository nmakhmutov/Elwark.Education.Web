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

public sealed partial class QuizMainPage : ComponentBase
{
    private ApiResult<EpochQuizBuilderModel> _response = ApiResult<EpochQuizBuilderModel>.Loading();
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
        _response = await QuizClient.GetTestBuilderAsync();
        _response.MatchError(x =>
        {
            if (x.IsQuizAlreadyCreated(out var id))
                Navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
        });
    }

    private async Task CreateQuizAsync(DifficultyType difficulty)
    {
        var quiz = await QuizClient.CreateAsync(new CreateQuizRequest(difficulty, _settings.Epoch));
        quiz.Match(
            x => Navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );
    }

    private async Task ChangeEpochAsync(EpochType epoch)
    {
        _settings = new QuizSettings(epoch);

        await Storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }
}
