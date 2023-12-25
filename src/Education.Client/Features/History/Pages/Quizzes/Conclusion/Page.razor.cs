using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes.Conclusion;

public sealed partial class Page
{
    private ApiResult<QuizConclusionModel> _result = ApiResult<QuizConclusionModel>.Loading();

    [Inject]
    private IHistoryQuizClient QuizClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        _result = await QuizClient.GetConclusionAsync(Id);

        if (_result.Is(x => x.IsQuizNotFound()))
            Navigation.NavigateTo(HistoryUrl.Quiz.Index());
    }

    private static Severity GetColor(QuizStatus status) =>
        status switch
        {
            QuizStatus.QuizSucceeded => Severity.Success,
            QuizStatus.QuizFailed => Severity.Error,
            QuizStatus.QuizTimeExceeded => Severity.Warning,
            QuizStatus.QuizMistakesExceeded => Severity.Warning,
            _ => Severity.Info
        };
}
