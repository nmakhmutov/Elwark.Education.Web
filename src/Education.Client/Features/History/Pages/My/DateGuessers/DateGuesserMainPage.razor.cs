using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.DateGuessers;

public sealed partial class DateGuesserMainPage : ComponentBase
{
    private DateGuesserProgressModel[] _daily = [];
    private DateGuesserProgressModel[] _monthly = [];
    private ApiResult<DateGuessersStatisticsModel> _result = ApiResult<DateGuessersStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["History_DateGuessers_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _result = await LearnerClient.GetDateGuesserStatisticsAsync();
        _result.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily
                .FillDailyGaps(today, x => x.Date, x => new DateGuesserProgressModel(x, 0, 0, 0))
                .ToArray();

            _monthly = model.Monthly
                .FillMonthlyGaps(today, x => x.Date, x => new DateGuesserProgressModel(x, 0, 0, 0))
                .ToArray();
        });
    }
}
