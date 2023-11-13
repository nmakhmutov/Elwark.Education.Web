using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Learner.Model.DateGuesser;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.DateGuessers;

public sealed partial class Page
{
    private DateGuessersStatisticsModel.ProgressModel[] _daily =
        Array.Empty<DateGuessersStatisticsModel.ProgressModel>();

    private DateGuessersStatisticsModel.ProgressModel[] _monthly =
        Array.Empty<DateGuessersStatisticsModel.ProgressModel>();

    private ApiResult<DateGuessersStatisticsModel> _result = ApiResult<DateGuessersStatisticsModel>.Loading();

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile)
    ];

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _result = await LearnerService.GetDateGuesserStatisticsAsync();
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
