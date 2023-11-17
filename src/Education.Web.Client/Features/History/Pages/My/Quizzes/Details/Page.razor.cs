using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Features.History.Services.Learner.Model.Quiz;
using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.My.Quizzes.Details;

public sealed partial class Page
{
    private QuizStatisticsModel.DailyProgress[] _progress = Array.Empty<QuizStatisticsModel.DailyProgress>();
    private ApiResult<QuizStatisticsModel> _result = ApiResult<QuizStatisticsModel>.Loading();
    private string? _title;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Profile_Title"], HistoryUrl.User.MyProfile),
        new BreadcrumbItem(L["Quizzes_Title"], HistoryUrl.User.MyQuizzes),
        new BreadcrumbItem(_title ?? string.Empty, null, true)
    ];

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    [Parameter]
    public string? Test { get; set; }

    protected override void OnParametersSet() =>
        _title = Test?.ToLowerInvariant() switch
        {
            "easy" => L["Quizzes_Easy_Title"],
            "hard" => L["Quizzes_Hard_Title"],
            _ => L["Error_NotFound"]
        };

    protected override async Task OnParametersSetAsync()
    {
        _result = Test?.ToLowerInvariant() switch
        {
            "easy" => await LearnerService.GetEasyQuizStatisticsAsync(),
            "hard" => await LearnerService.GetHardQuizStatisticsAsync(),
            _ => ApiResult<QuizStatisticsModel>.Fail(Error.Create(L["Error_NotFound"], 404))
        };

        _progress = _result
            .Map(m => m.Progress.FillDailyGaps(m.Delta.Start, m.Delta.End, x => x.Date, x => EmptyProgress(x)))
            .UnwrapOrElse(Enumerable.Empty<QuizStatisticsModel.DailyProgress>)
            .ToArray();
    }

    private static QuizStatisticsModel.DailyProgress EmptyProgress(DateOnly date) =>
        new(
            date,
            new ScoreModel(0, 0, 0, 0),
            new AnswerRatioModel(0, 0, 0, 0, 0),
            new QuizStatisticsModel.TimeSpentModel(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero),
            new NumberOfQuizzesModel(0, 0, 0, 0, 0)
        );
}
