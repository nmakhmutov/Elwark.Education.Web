using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Examinations;

public sealed partial class ExaminationMainPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ExaminationProgressModel[] _daily = [];
    private ExaminationProgressModel[] _monthly = [];
    private ApiResult<ExaminationsStatisticsModel> _response = ApiResult<ExaminationsStatisticsModel>.Loading();

    public ExaminationMainPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
            new BreadcrumbItem(_localizer["Examinations_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync()
    {
        _response = await _learnerClient.GetExaminationStatisticsAsync();
        _response.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily
                .FillDailyGaps(today, x => x.Date, x => new ExaminationProgressModel(x, 0, 0))
                .ToArray();

            _monthly = model.Monthly
                .FillMonthlyGaps(today, x => x.Date, x => new ExaminationProgressModel(x, 0, 0))
                .ToArray();
        });
    }
}
