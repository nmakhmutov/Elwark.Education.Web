using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients;
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
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ExaminationStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<ExaminationStatisticsModel> _response = ApiResult<ExaminationStatisticsModel>.Loading();
    private string? _title;

    public ExaminationDetailPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
    }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new(_localizer["Examinations_Title"], HistoryUrl.User.MyExaminations),
        new(_title ?? string.Empty, null, true)
    ];

    [Parameter]
    public string? Test { get; set; }

    protected override async Task OnInitializedAsync()
    {
        (_title, _response) = Test?.ToLowerInvariant() switch
        {
            "easy" => (_localizer["Examinations_Easy_Title"], await _learnerClient.GetEasyExaminationStatisticsAsync()),
            "hard" => (_localizer["Examinations_Hard_Title"], await _learnerClient.GetHardExaminationStatisticsAsync()),
            _ => (_localizer["Error_NotFound"], ApiResult<ExaminationStatisticsModel>.Fail(Error.Create(_localizer["Error_NotFound"])))
        };

        _progress = _response
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(() => [])
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
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Successful_Title"], contrast.Successful),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Failed_Title"], contrast.Failed),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_TimeExceeded_Title"], contrast.TimeExceeded),
        ProgressList.Item.Create(_localizer["NumberOfQuizzes_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.ScoreContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["Score_Questions_Title"], contrast.Questions),
        ProgressList.Item.Create(_localizer["Score_TimeBonus_Title"], contrast.TimeBonus),
        ProgressList.Item.Create(_localizer["Score_AccuracyBonus_Title"], contrast.AccuracyBonus),
        ProgressList.Item.Create(_localizer["Score_Total_Title"], contrast.Total)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["Questions_Answered"], contrast.Answered),
        ProgressList.Item.Create(_localizer["Questions_NotAnswered"], contrast.NotAnswered),
        ProgressList.Item.Create(_localizer["Questions_Correct"], contrast.Correct),
        ProgressList.Item.Create(_localizer["Questions_Incorrect"], contrast.Incorrect),
        ProgressList.Item.Create(_localizer["Questions_Total"], contrast.Questions)
    ];

    private ProgressList.Item[] GetProgress(ExaminationStatisticsModel.TimeSpentContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["TimeSpent_Min_Title"], contrast.Min, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Max_Title"], contrast.Max, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Average_Title"], contrast.Average, _localizer),
        ProgressList.Item.Create(_localizer["TimeSpent_Total_Title"], contrast.Total, _localizer)
    ];
}
