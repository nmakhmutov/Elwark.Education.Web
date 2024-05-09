using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Components.Lists;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using AnswerRatioModel = Education.Client.Features.History.Clients.Learner.Model.DateGuesser.AnswerRatioModel;

namespace Education.Client.Features.History.Pages.My.DateGuessers.Details;

public sealed partial class Page
{
    private DateGuesserStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<DateGuesserStatisticsModel> _result = ApiResult<DateGuesserStatisticsModel>.Loading();
    private string? _title;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["History_DateGuessers_Title"], HistoryUrl.User.MyDateGuessers),
        new BreadcrumbItem(_title ?? string.Empty, null, true)
    ];

    [Parameter]
    public required string Test { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        (_title, _result) = Test.ToLowerInvariant() switch
        {
            "small" => (L["History_DateGuessers_Small"], await LearnerClient.GetSmallDateGuesserStatisticsAsync()),
            "medium" => (L["History_DateGuessers_Medium"], await LearnerClient.GetMediumDateGuesserStatisticsAsync()),
            "large" => (L["History_DateGuessers_Large"], await LearnerClient.GetLargeDateGuesserStatisticsAsync()),
            _ => (L["Error_NotFound"],
                ApiResult<DateGuesserStatisticsModel>.Fail(Error.Create(L["Error_NotFound"], 404)))
        };

        _progress = _result
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(Enumerable.Empty<DateGuesserStatisticsModel.DailyProgress>)
            .ToArray();
    }

    private static DateGuesserStatisticsModel.DailyProgress EmptyProgress(DateOnly date) =>
        new(date, 0, new ScoreModel(0, 0, 0), new AnswerRatioModel(0, 0, 0));

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.ScoreContrastModel score) =>
    [
        ProgressList.Item.Create(L["History_DateGuesser_Score"], score.Total),
        ProgressList.Item.Create(L["History_DateGuesser_Points"], score.Points),
        ProgressList.Item.Create(L["History_DateGuesser_x2Bonus"], score.Bonus)
    ];

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(L["History_DateGuesser_Questions"], contrast.Total),
        ProgressList.Item.Create(L["History_DateGuesser_Correct"], contrast.Correct),
        ProgressList.Item.Create(L["History_DateGuesser_Incorrect"], contrast.Incorrect)
    ];

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.DeltaModel delta) =>
    [
        ProgressList.Item.Create(L["History_DateGuesser_Total"], delta.Tests)
    ];
}
