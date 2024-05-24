using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes.Conclusion;

public sealed partial class Page : ComponentBase
{
    private ApiResult<QuizConclusionModel> _response = ApiResult<QuizConclusionModel>.Loading();

    [Inject]
    private IHistoryQuizClient QuizClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _response = await QuizClient.GetConclusionAsync(Id);

        if (_response.MatchError(x => x.IsQuizNotFound()))
            Navigation.NavigateTo(HistoryUrl.Quiz.Index());
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

    private static string GetCheckIcon(bool isChecked) =>
        isChecked ? Icons.Material.Outlined.Check : Icons.Material.Outlined.Close;
}
