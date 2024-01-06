using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Examinations.Details;

public sealed partial class Page
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
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
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
}
