using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Quizzes.Conclusion;

public sealed partial class Page
{
    private ApiResult<QuizConclusionModel> _result = ApiResult<QuizConclusionModel>.Loading();

    [Inject]
    private IHistoryQuizService QuizService { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        _result = await QuizService.GetConclusionAsync(Id);

        if (_result.Is(x => x.IsQuizNotFound()))
            Navigation.NavigateTo(HistoryUrl.Quiz.Index());
    }

    private static Severity GetColor(QuizStatus status) =>
        status switch
        {
            QuizStatus.Succeeded => Severity.Success,
            QuizStatus.Failed => Severity.Error,
            QuizStatus.TimeExceeded => Severity.Warning,
            QuizStatus.MistakesExceeded => Severity.Warning,
            _ => Severity.Info
        };
}
