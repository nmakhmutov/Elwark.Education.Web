using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients;
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
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private QuizStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<QuizStatisticsModel> _response = ApiResult<QuizStatisticsModel>.Loading();
    private string? _title;

    public QuizDetailPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Quizzes_Title"], HistoryUrl.User.MyQuizzes)
        ];
    }

    [Parameter]
    public string? Test { get; set; }

    protected override async Task OnInitializedAsync()
    {
        (_title, _response) = Test?.ToLowerInvariant() switch
        {
            "easy" => (_localizer["Quizzes_Easy_Title"], await _learnerClient.GetEasyQuizStatisticsAsync()),
            "hard" => (_localizer["Quizzes_Hard_Title"], await _learnerClient.GetHardQuizStatisticsAsync()),
            "expert" => (_localizer["Quizzes_Expert_Title"], await _learnerClient.GetExpertQuizStatisticsAsync()),
            _ => (_localizer["Error_NotFound"],
                ApiResult<QuizStatisticsModel>.Fail(Error.Create(_localizer["Error_NotFound"])))
        };

        _breadcrumbs.Add(new BreadcrumbItem(_title, null, true));

        _progress = _response
            .Map(m => m.Progress.FillDailyGaps( m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
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
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Successful_Title"], contrast.Successful),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Failed_Title"], contrast.Failed),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_MistakesLimitExceeded_Title"],
            contrast.MistakesLimitExceeded),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.ScoreContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["Score_Questions_Title"], contrast.Questions),
        ProgressList.Item.Create(_localizer["Score_TimeBonus_Title"], contrast.TimeBonus),
        ProgressList.Item.Create(_localizer["Score_AccuracyBonus_Title"], contrast.AccuracyBonus),
        ProgressList.Item.Create(_localizer["Score_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["Questions_Answered"], contrast.Answered),
        ProgressList.Item.Create(_localizer["Questions_NotAnswered"], contrast.NotAnswered),
        ProgressList.Item.Create(_localizer["Questions_Correct"], contrast.Correct),
        ProgressList.Item.Create(_localizer["Questions_Incorrect"], contrast.Incorrect),
        ProgressList.Item.Create(_localizer["Questions_Total"], contrast.Questions)
    ];

    private ProgressList.Item[] GetProgress(QuizStatisticsModel.TimeSpentContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["TimeSpent_Min_Title"], contrast.Min, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Max_Title"], contrast.Max, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Average_Title"], contrast.Average, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Total_Title"], contrast.Total, _localizer)
    ];
}
