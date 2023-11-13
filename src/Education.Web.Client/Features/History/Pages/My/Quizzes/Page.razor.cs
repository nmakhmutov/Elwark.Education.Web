using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Learner.Model.Quiz;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Quizzes;

public sealed partial class Page
{
    private QuizzesStatisticsModel.ProgressModel[] _daily = Array.Empty<QuizzesStatisticsModel.ProgressModel>();
    private QuizzesStatisticsModel.ProgressModel[] _monthly = Array.Empty<QuizzesStatisticsModel.ProgressModel>();
    private ApiResult<QuizzesStatisticsModel> _result = ApiResult<QuizzesStatisticsModel>.Loading();

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
        _result = await LearnerService.GetQuizStatisticsAsync();
        _result.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily
                .FillDailyGaps(today, x => x.Date, x => new QuizzesStatisticsModel.ProgressModel(x, 0, 0))
                .ToArray();

            _monthly = model.Monthly
                .FillMonthlyGaps(today, x => x.Date, x => new QuizzesStatisticsModel.ProgressModel(x, 0, 0))
                .ToArray();
        });
    }
}
