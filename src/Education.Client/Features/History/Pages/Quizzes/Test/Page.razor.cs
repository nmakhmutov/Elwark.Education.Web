using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes.Test;

public sealed partial class Page: ComponentBase
{
    private AnswerResult? _correctAnswer;
    private ApiResult<QuizModel> _quiz = ApiResult<QuizModel>.Loading();

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
        _quiz.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _quiz = await QuizClient.GetAsync(Id);
        _quiz.MatchError(x => HandlerError(x));
    }

    private async Task OnExpiredAsync()
    {
        _quiz = await QuizClient.GetAsync(Id);
        _quiz.MatchError(x => HandlerError(x));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var quiz = _quiz.Unwrap();
        var result = await QuizClient.CheckAsync(quiz.TestId, quiz.Question.Id, answer);

        result.Match(x => HandleSuccess(x), e => HandlerError(e));
        return;

        void HandleSuccess(QuizAnswerModel model)
        {
            _correctAnswer = model.Answer;
            _quiz = ApiResult<QuizModel>.Success(quiz with
            {
                CompletedQuestions = model.CompletedQuestions,
                TotalQuestions = model.TotalQuestions,
                IsCompleted = model.IsCompleted
            });

            StateHasChanged();
        }
    }

    private async Task OnNextAsync()
    {
        if (_quiz.Map(x => x.IsCompleted).Unwrap())
        {
            Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
        }
        else
        {
            _correctAnswer = null;
            _quiz = await QuizClient.GetAsync(Id);

            StateHasChanged();
        }
    }

    private async Task OnUseInventory(uint id)
    {
        _quiz = await QuizClient.UseInventoryAsync(Id, id);
        _quiz.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsQuizAlreadyCompleted() || error.IsQuizExpired())
            Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
        else
            Snackbar.Add(error.Title, Severity.Error);
    }
}
