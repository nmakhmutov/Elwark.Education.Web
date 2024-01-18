using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes.Test;

public sealed partial class Page
{
    private AnswerResult? _correctAnswer;
    private ApiResult<QuizModel> _result = ApiResult<QuizModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryQuizClient QuizClient { get; init; } = default!;

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
        _result = await QuizClient.GetAsync(Id);
        _result.MathError(_ => Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id)));
    }

    private async Task OnExpiredAsync()
    {
        _result = await QuizClient.GetAsync(Id);
        _result.MathError(_ => Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id)));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var quiz = _result.Unwrap();
        var result = await QuizClient.CheckAsync(quiz.TestId, quiz.Question.Id, answer);

        result.Match(x =>
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
        _result = await QuizClient.GetAsync(Id);

        StateHasChanged();
    }

    private async Task OnUseInventory(uint id)
    {
        _result = await QuizClient.ApplyInventoryAsync(Id, id);
        _result.MathError(e => Snackbar.Add(e.Detail, Severity.Error));
    }
}
