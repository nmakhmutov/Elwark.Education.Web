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
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IHistoryQuizClient _quizClient;
    private readonly ISnackbar _snackbar;
    private readonly ILocalStorageService _storage;
    private ApiResult<EpochQuizBuilderModel> _response = ApiResult<EpochQuizBuilderModel>.Loading();
    private QuizSettings _settings = QuizSettings.Empty;

    public QuizMainPage(
        IStringLocalizer<App> localizer,
        IHistoryQuizClient quizClient,
        NavigationManager navigation,
        ISnackbar snackbar,
        ILocalStorageService storage
    )
    {
        _localizer = localizer;
        _quizClient = quizClient;
        _navigation = navigation;
        _snackbar = snackbar;
        _storage = storage;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["Quizzes_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync()
    {
        _response = await _quizClient.GetTestBuilderAsync();
        _response.MatchError(error =>
        {
            if (error.IsQuizAlreadyCreated(out var id))
                _navigation.NavigateTo(HistoryUrl.Quiz.Test(id));
        });

        _settings = await _storage.GetItemAsync<QuizSettings>(HistoryLocalStorageKey.QuizSettings) ?? _settings;
    }

    private async Task CreateQuizAsync(DifficultyType difficulty)
    {
        var quiz = await _quizClient.CreateAsync(new CreateQuizRequest(difficulty, _settings.Epoch));
        quiz.Match(
            x => _navigation.NavigateTo(HistoryUrl.Quiz.Test(x.Id)),
            e => _snackbar.Add(e.UiMessage, Severity.Error)
        );
    }

    private async Task ChangeEpochAsync(EpochType epoch)
    {
        _settings = new QuizSettings(epoch);

        await _storage.SetItemAsync(HistoryLocalStorageKey.QuizSettings, _settings);
    }
}
