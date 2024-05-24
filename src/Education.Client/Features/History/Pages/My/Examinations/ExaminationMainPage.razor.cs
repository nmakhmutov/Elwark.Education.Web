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
    private ExaminationProgressModel[] _daily = [];
    private ExaminationProgressModel[] _monthly = [];
    private ApiResult<ExaminationsStatisticsModel> _response = ApiResult<ExaminationsStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Examinations_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _response = await LearnerClient.GetExaminationStatisticsAsync();
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
