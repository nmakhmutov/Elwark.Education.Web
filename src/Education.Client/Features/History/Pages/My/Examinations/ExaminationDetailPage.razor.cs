using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Features.History.Components.Lists;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Examinations;

public sealed partial class ExaminationDetailPage : ComponentBase
{
    private ExaminationStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<ExaminationStatisticsModel> _result = ApiResult<ExaminationStatisticsModel>.Loading();
    private string? _title;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Examinations_Title"], HistoryUrl.User.MyExaminations),
        new BreadcrumbItem(_title ?? string.Empty, null, true)
    ];

    [Parameter]
    public string? Test { get; set; }

    protected override void OnParametersSet() =>
        _title = Test?.ToLowerInvariant() switch
        {
            "easy" => L["Examinations_Easy_Title"],
            "hard" => L["Examinations_Hard_Title"],
            _ => L["Error_NotFound"]
        };

    protected override async Task OnParametersSetAsync()
    {
        _result = Test?.ToLowerInvariant() switch
        {
            "easy" => await LearnerClient.GetEasyExaminationStatisticsAsync(),
            "hard" => await LearnerClient.GetHardExaminationStatisticsAsync(),
            _ => ApiResult<ExaminationStatisticsModel>.Fail(Error.Create(L["Error_NotFound"], 404))
        };

        _progress = _result
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(Enumerable.Empty<ExaminationStatisticsModel.DailyProgress>)
            .ToArray();
    }

    private static ExaminationStatisticsModel.DailyProgress EmptyProgress(DateOnly date) =>
        new(
            date,
            new ScoreModel(0, 0, 0, 0),
            new AnswerRatioModel(0, 0, 0, 0, 0),
            new ExaminationStatisticsModel.TimeSpentModel(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero),
            new NumberOfExaminationsModel(0, 0, 0, 0)
        );

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.NumberOfExaminationsContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["NumberOfQuizzes_Successful_Title"], contrast.Successful),
        ProgressList.Item.Create(L["NumberOfQuizzes_Failed_Title"], contrast.Failed),
        ProgressList.Item.Create(L["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded),
        ProgressList.Item.Create(L["NumberOfQuizzes_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.ScoreContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["Score_Questions_Title"], contrast.Questions),
        ProgressList.Item.Create(L["Score_SpeedBonus_Title"], contrast.Speed),
        ProgressList.Item.Create(L["Score_NoMistakesBonus_Title"], contrast.NoMistakes),
        ProgressList.Item.Create(L["Score_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["Questions_Answered"], contrast.Answered),
        ProgressList.Item.Create(L["Questions_NotAnswered"], contrast.NotAnswered),
        ProgressList.Item.Create(L["Questions_Correct"], contrast.Correct),
        ProgressList.Item.Create(L["Questions_Incorrect"], contrast.Incorrect),
        ProgressList.Item.Create(L["Questions_Total"], contrast.Questions)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.TimeSpentContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["TimeSpent_Min_Title"], contrast.Min, L),
        ProgressList.Item.Create(L["TimeSpent_Max_Title"], contrast.Max, L),
        ProgressList.Item.Create(L["TimeSpent_Average_Title"], contrast.Average, L),
        ProgressList.Item.Create(L["TimeSpent_Total_Title"], contrast.Total, L)
    ];
}
