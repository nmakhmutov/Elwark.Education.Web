using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Quizzes.Test;

public sealed partial class Page
{
    private AnswerResult? _correctAnswer;
    private ApiResult<QuizModel> _result = ApiResult<QuizModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryQuizService QuizService { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private double Progress =>
        _result.Match(x => (double)x.CompletedQuestions / x.TotalQuestions * 100, _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _result = await QuizService.GetAsync(Id);
        _result.MathError(e =>
        {
            if (e.IsQuizAlreadyCompleted() || e.IsQuizNotFound() || e.IsQuizExpired())
                Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
        });
    }

    private async Task OnExpiredAsync()
    {
        _result = await QuizService.GetAsync(Id);
        _result.MathError(_ => Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id)));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var quiz = _result.Unwrap();
        (await QuizService.CheckAsync(quiz.Id, quiz.Question.Id, answer))
            .Match(
                x =>
                {
                    _correctAnswer = x.Answer;
                    _result = ApiResult<QuizModel>.Success(quiz with
                    {
                        CompletedQuestions = x.CompletedQuestions,
                        TotalQuestions = x.TotalQuestions,
                        IsCompleted = x.IsCompleted
                    });

                    StateHasChanged();
                },
                e =>
                {
                    if (e.IsQuizAlreadyCompleted())
                        Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
                    else
                        Snackbar.Add(e.Detail, Severity.Error);
                });
    }

    private async Task OnNextAsync()
    {
        var quiz = _result.Unwrap();
        if (quiz.IsCompleted)
        {
            Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
            return;
        }

        _correctAnswer = null;
        _result = await QuizService.GetAsync(Id);

        StateHasChanged();
    }

    private async Task OnUseInventory(uint id)
    {
        _result = await QuizService.ApplyInventoryAsync(Id, id);
        _result.MathError(e => Snackbar.Add(e.Detail, Severity.Error));
    }
}
