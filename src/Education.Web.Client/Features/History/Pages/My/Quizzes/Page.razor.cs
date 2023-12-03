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
    private QuizzesStatisticsModel.ProgressModel[] _daily = [];
    private QuizzesStatisticsModel.ProgressModel[] _monthly = [];
    private ApiResult<QuizzesStatisticsModel> _result = ApiResult<QuizzesStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Quizzes_Title"], null, true)
    ];

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
