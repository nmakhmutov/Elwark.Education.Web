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
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private DateGuesserProgressModel[] _daily = [];
    private DateGuesserProgressModel[] _monthly = [];
    private ApiResult<DateGuessersStatisticsModel> _response = ApiResult<DateGuessersStatisticsModel>.Loading();

    public DateGuesserMainPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["History_DateGuessers_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync()
    {
        _response = await _learnerClient.GetDateGuesserStatisticsAsync();
        _response.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily.FillDailyGaps(today, x => x.Date, x => new DateGuesserProgressModel(x, 0, 0, 0))
                .ToArray();

            _monthly = model.Monthly.FillMonthlyGaps(today, x => x.Date, x => new DateGuesserProgressModel(x, 0, 0, 0))
                .ToArray();
        });
    }
}
