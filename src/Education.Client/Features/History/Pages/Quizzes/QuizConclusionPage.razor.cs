using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes;

public sealed partial class QuizConclusionPage : ComponentBase
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IHistoryQuizClient _quizClient;
    private ApiResult<QuizConclusionModel> _response = ApiResult<QuizConclusionModel>.Loading();

    public QuizConclusionPage(
        IHistoryQuizClient quizClient,
        IStringLocalizer<App> localizer,
        NavigationManager navigation
    )
    {
        _quizClient = quizClient;
        _localizer = localizer;
        _navigation = navigation;
    }

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _response = await _quizClient.GetConclusionAsync(Id);

        if (_response.MatchError(x => x.IsQuizNotFound()))
            _navigation.NavigateTo(HistoryUrl.Quiz.Index());
    }

    private static Severity GetColor(QuizStatus status) =>
        status switch
        {
            QuizStatus.Succeeded => Severity.Success,
            QuizStatus.Failed => Severity.Error,
            QuizStatus.TimeExceeded => Severity.Warning,
            QuizStatus.MistakesLimitExceeded => Severity.Warning,
            _ => Severity.Info
        };
}
