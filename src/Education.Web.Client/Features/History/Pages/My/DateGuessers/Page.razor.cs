using Education.Web.Client.Clients;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Clients.Learner;
using Education.Web.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.DateGuessers;

public sealed partial class Page
{
    private DateGuessersStatisticsModel.ProgressModel[] _daily = [];
    private DateGuessersStatisticsModel.ProgressModel[] _monthly = [];
    private ApiResult<DateGuessersStatisticsModel> _result = ApiResult<DateGuessersStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["History_DateGuessers_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _result = await LearnerClient.GetDateGuesserStatisticsAsync();
        _result.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily
                .FillDailyGaps(today, x => x.Date, x => new DateGuessersStatisticsModel.ProgressModel(x, 0, 0, 0))
                .ToArray();

            _monthly = model.Monthly
                .FillMonthlyGaps(today, x => x.Date, x => new DateGuessersStatisticsModel.ProgressModel(x, 0, 0, 0))
                .ToArray();
        });
    }
}
