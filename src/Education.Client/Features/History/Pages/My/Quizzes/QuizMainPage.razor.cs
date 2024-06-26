using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Quizzes;

public sealed partial class QuizMainPage : ComponentBase
{
    private QuizProgressModel[] _daily = [];
    private QuizProgressModel[] _monthly = [];
    private ApiResult<QuizzesStatisticsModel> _response = ApiResult<QuizzesStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Quizzes_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _response = await LearnerClient.GetQuizStatisticsAsync();
        _response.Match(model =>
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            _daily = model.Daily
                .FillDailyGaps(today, x => x.Date, x => new QuizProgressModel(x, 0, 0))
                .ToArray();

            _monthly = model.Monthly
                .FillMonthlyGaps(today, x => x.Date, x => new QuizProgressModel(x, 0, 0))
                .ToArray();
        });
    }
}
