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

namespace Education.Client.Features.History.Pages.My.DateGuessers;

public sealed partial class DateGuesserDetailPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private DateGuesserStatisticsModel.DailyProgress[] _progress = [];
    private ApiResult<DateGuesserStatisticsModel> _response = ApiResult<DateGuesserStatisticsModel>.Loading();
    private string? _title;

    public DateGuesserDetailPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["History_DateGuessers_Title"], HistoryUrl.User.MyDateGuessers)
        ];
    }

    [Parameter]
    public required string Test { get; set; }

    protected override async Task OnInitializedAsync()
    {
        (_title, _response) = Test.ToLowerInvariant() switch
        {
            "small" => (
                _localizer["History_DateGuessers_Small"],
                await _learnerClient.GetSmallDateGuesserStatisticsAsync()
            ),
            "medium" => (
                _localizer["History_DateGuessers_Medium"],
                await _learnerClient.GetMediumDateGuesserStatisticsAsync()
            ),
            "large" => (
                _localizer["History_DateGuessers_Large"],
                await _learnerClient.GetLargeDateGuesserStatisticsAsync()
            ),
            _ => (
                _localizer["Error_NotFound"],
                ApiResult<DateGuesserStatisticsModel>.Fail(Error.Create(_localizer["Error_NotFound"]))
            )
        };

        _breadcrumbs.Add(new BreadcrumbItem(_title, null, true));

        _progress = _response
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(Enumerable.Empty<DateGuesserStatisticsModel.DailyProgress>)
            .ToArray();
    }

    private static DateGuesserStatisticsModel.DailyProgress EmptyProgress(DateOnly date) =>
        new(date, 0, new ScoreModel(0, 0, 0), new AnswerRatioModel(0, 0, 0));

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.ScoreContrastModel score) =>
    [
        ProgressList.Item.Create(_localizer["History_DateGuesser_Score"], score.Total),
        ProgressList.Item.Create(_localizer["History_DateGuesser_Points"], score.Points),
        ProgressList.Item.Create(_localizer["History_DateGuesser_x2Bonus"], score.Bonus)
    ];

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.AnswerRatioContrastModel contrast) =>
    [
        ProgressList.Item.Create(_localizer["History_DateGuesser_Questions"], contrast.Total),
        ProgressList.Item.Create(_localizer["History_DateGuesser_Correct"], contrast.Correct),
        ProgressList.Item.Create(_localizer["History_DateGuesser_Incorrect"], contrast.Incorrect)
    ];

    private ProgressList.Item[] GetProgress(DateGuesserStatisticsModel.DeltaModel delta) =>
    [
        ProgressList.Item.Create(_localizer["History_DateGuesser_Total"], delta.Tests)
    ];
}
