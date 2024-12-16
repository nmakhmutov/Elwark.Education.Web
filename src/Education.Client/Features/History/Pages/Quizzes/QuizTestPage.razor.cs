using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Quizzes;

public sealed partial class QuizTestPage : ComponentBase
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IHistoryQuizClient _quizClient;
    private readonly ISnackbar _snackbar;

    private AnswerResult? _correctAnswer;
    private ApiResult<QuizModel> _response = ApiResult<QuizModel>.Loading();

    public QuizTestPage(
        IStringLocalizer<App> localizer,
        IHistoryQuizClient quizClient,
        NavigationManager navigation,
        ISnackbar snackbar
    )
    {
        _localizer = localizer;
        _quizClient = quizClient;
        _navigation = navigation;
        _snackbar = snackbar;
    }

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private double Progress =>
        _response.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _response = await _quizClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnExpiredAsync()
    {
        _response = await _quizClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var quiz = _response.Unwrap();
        var result = await _quizClient.CheckAsync(quiz.TestId, quiz.Question.Id, answer);

        result.Match(x => HandleSuccess(x), e => HandlerError(e));
        return;

        void HandleSuccess(QuizAnswerModel model)
        {
            _correctAnswer = model.Answer;
            _response = ApiResult<QuizModel>.Success(quiz with
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
        if (_response.Map(x => x.IsCompleted).Unwrap())
        {
            _navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
        }
        else
        {
            _correctAnswer = null;
            _response = await _quizClient.GetAsync(Id);

            StateHasChanged();
        }
    }

    private async Task OnUseInventory(uint id)
    {
        _response = await _quizClient.UseInventoryAsync(Id, id);
        _response.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsQuizAlreadyCompleted() || error.IsQuizExpired())
            _navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
        else
            _snackbar.Add(error.Title, Severity.Error);
    }
}
