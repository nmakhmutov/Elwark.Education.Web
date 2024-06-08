using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Features.History.Components.Lists;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Quizzes;

public sealed partial class QuizDetailPage : ComponentBase
{
    private QuizStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<QuizStatisticsModel> _response = ApiResult<QuizStatisticsModel>.Loading();
    private string? _title;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Quizzes_Title"], HistoryUrl.User.MyQuizzes),
        new BreadcrumbItem(_title ?? string.Empty, null, true)
    ];

    [Parameter]
    public string? Test { get; set; }

    protected override async Task OnInitializedAsync()
    {
        (_title, _response) = Test?.ToLowerInvariant() switch
        {
            "easy" => (L["Quizzes_Easy_Title"], await LearnerClient.GetEasyQuizStatisticsAsync()),
            "hard" => (L["Quizzes_Hard_Title"], await LearnerClient.GetHardQuizStatisticsAsync()),
            _ => (L["Error_NotFound"], ApiResult<QuizStatisticsModel>.Fail(Error.Create(L["Error_NotFound"])))
        };

        _progress = _response
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(Enumerable.Empty<QuizStatisticsModel.DailyProgress>)
            .ToArray();
    }

    private static QuizStatisticsModel.DailyProgress EmptyProgress(DateOnly date) =>
        new(
            date,
            new ScoreModel(0, 0, 0, 0),
            new AnswerRatioModel(0, 0, 0, 0, 0),
            new QuizStatisticsModel.TimeSpentModel(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero),
            new NumberOfQuizzesModel(0, 0, 0, 0, 0)
        );

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.NumberOfQuizzesContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["NumberOfQuizzes_Successful_Title"], contrast.Successful),
        ProgressList.Item.Create(L["NumberOfQuizzes_Failed_Title"], contrast.Failed),
        ProgressList.Item.Create(L["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded),
        ProgressList.Item.Create(L["NumberOfQuizzes_MistakesLimitExceeded_Title"], contrast.MistakesLimitExceeded),
        ProgressList.Item.Create(L["NumberOfQuizzes_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.ScoreContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["Score_Questions_Title"], contrast.Questions),
        ProgressList.Item.Create(L["Score_TimeBonus_Title"], contrast.TimeBonus),
        ProgressList.Item.Create(L["Score_AccuracyBonus_Title"], contrast.AccuracyBonus),
        ProgressList.Item.Create(L["Score_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["Questions_Answered"], contrast.Answered),
        ProgressList.Item.Create(L["Questions_NotAnswered"], contrast.NotAnswered),
        ProgressList.Item.Create(L["Questions_Correct"], contrast.Correct),
        ProgressList.Item.Create(L["Questions_Incorrect"], contrast.Incorrect),
        ProgressList.Item.Create(L["Questions_Total"], contrast.Questions)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.TimeSpentContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["TimeSpent_Min_Title"], contrast.Min, L),
        ProgressList.Item.Create(L["TimeSpent_Max_Title"], contrast.Max, L),
        ProgressList.Item.Create(L["TimeSpent_Average_Title"], contrast.Average, L),
        ProgressList.Item.Create(L["TimeSpent_Total_Title"], contrast.Total, L)
    ];
}
