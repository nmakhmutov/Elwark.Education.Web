using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Quizzes.Test;

public sealed partial class Page
{
    private ApiResult<QuizModel> _result = ApiResult<QuizModel>.Loading();
    private TestInventoryModel[] _inventory = Array.Empty<TestInventoryModel>();
    private Color _countdownColor = Color.Default;
    private QuizOverviewModel _quiz = default!;
    private Question _currentQuestion = default!;
    private Question? _nextQuestion;
    private AnswerResult? _correctAnswer;
    private string _testTypeTitle = string.Empty;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryQuizService QuizService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private double Progress =>
        (double)_quiz.Completed / _quiz.Questions * 100;

    protected override async Task OnInitializedAsync()
    {
        _result = await QuizService.GetAsync(Id);
        _result.Match(
            x =>
            {
                _quiz = x.Overview;
                _currentQuestion = x.Question;
                _inventory = x.Inventory;
                _testTypeTitle = L[$"Quiz_{_quiz.Type}_Title"];
            },
            e =>
            {
                if (e.IsQuizAlreadyCompleted() || e.IsQuizNotFound())
                    Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
            });
    }

    private async Task OnExpired()
    {
        _countdownColor = Color.Error;
        _result = await QuizService.GetAsync(Id);

        if (_result.IsError)
            Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
    }

    private async Task OnAnswer(AnswerToQuestionModel answer)
    {
        var result = await QuizService.CheckAsync(_quiz.Id, _currentQuestion.Id, answer);
        UpdateState(result);
    }

    private void UpdateState(ApiResult<QuizAnswerModel> result) =>
        result.Match(
            x =>
            {
                _quiz = x.Overview;
                _inventory = x.Inventory;
                _nextQuestion = x.NextQuestion;
                _correctAnswer = x.Answer;

                StateHasChanged();
            },
            e =>
            {
                if (e.IsQuizAlreadyCompleted())
                    Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
                else
                    Snackbar.Add(e.Detail, Severity.Error);
            });

    private void OnNext()
    {
        if (_nextQuestion is null)
        {
            Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
            return;
        }

        _currentQuestion = _nextQuestion;
        _nextQuestion = null;
        _correctAnswer = null;

        StateHasChanged();
    }

    private async Task OnUseInventory(uint id) =>
        (await QuizService.ApplyInventoryAsync(_quiz.Id, id))
        .Match(
            x =>
            {
                if (x.Question is null)
                {
                    Navigation.NavigateTo(HistoryUrl.Quiz.Conclusion(Id));
                    return;
                }

                _quiz = x.Overview;
                _currentQuestion = x.Question;
                _inventory = x.Inventory;
            },
            e => Snackbar.Add(e.Detail, Severity.Error)
        );
}
