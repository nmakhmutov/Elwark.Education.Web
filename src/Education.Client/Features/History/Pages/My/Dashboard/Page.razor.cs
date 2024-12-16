using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MeOverviewModel = Education.Client.Features.History.Clients.Learner.Model.MeOverviewModel;

namespace Education.Client.Features.History.Pages.My.Dashboard;

using DateGuesserModel = MeOverviewModel.DateGuesserModel;
using ExaminationModel = MeOverviewModel.ExaminationModel;
using QuizModel = MeOverviewModel.QuizModel;

public sealed partial class Page : ComponentBase
{
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly IHistoryUserClient _userClient;
    private ApiResult<Aggregate> _response = ApiResult<Aggregate>.Loading();

    public Page(IStringLocalizer<App> localizer, IHistoryUserClient userClient, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _userClient = userClient;
        _learnerClient = learnerClient;
    }

    protected override async Task OnInitializedAsync()
    {
        var userRequest = await _userClient.GetMeAsync();
        if (userRequest.IsError)
        {
            _response = ApiResult<Aggregate>.Fail(userRequest.UnwrapError());
            return;
        }

        var learnerRequest = await _learnerClient.GetMeAsync();
        if (learnerRequest.IsError)
        {
            _response = ApiResult<Aggregate>.Fail(learnerRequest.UnwrapError());
            return;
        }

        var user = userRequest.Unwrap();
        var learner = learnerRequest.Unwrap();

        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var activities = learner.Activities
            .FillMonthlyGaps(today.AddMonths(-5), today, x => x.Month,
                month => new MeOverviewModel.ActivityModel(
                    month,
                    new ExaminationModel(0, 0),
                    new QuizModel(0, 0),
                    new DateGuesserModel(0, 0, 0)
                )
            )
            .ToArray();

        var (examination, quiz, dateGuesser) = activities switch
        {
            [.., var last, var current] => (
                MonthlyTrend.Map(learner.Examinations, current.Examination, last.Examination),
                MonthlyTrend.Map(learner.Quizzes, current.Quiz, last.Quiz),
                MonthlyTrend.Map(learner.DateGuessers, current.DateGuesser, last.DateGuesser)
            ),
            _ => (
                MonthlyTrend.Empty(learner.Examinations),
                MonthlyTrend.Empty(learner.Quizzes),
                MonthlyTrend.Empty(learner.DateGuessers)
            )
        };

        _response = ApiResult<Aggregate>.Success(
            new Aggregate(
                examination,
                quiz,
                dateGuesser,
                activities,
                user.MonthlyPerformance,
                user.Level,
                user.Backpack,
                user.Wallet,
                user.Assignments,
                user.Achievements
            )
        );
    }

    private sealed record Aggregate(
        MonthlyTrend Examinations,
        MonthlyTrend Quizzes,
        MonthlyTrend DateGuessers,
        MeOverviewModel.ActivityModel[] MonthlyActivities,
        Clients.User.Model.MeOverviewModel.MonthlyPerformanceModel MonthlyPerformance,
        UserLevelModel Level,
        BackpackOverviewModel Backpack,
        Dictionary<GameCurrency, long> Wallet,
        Clients.User.Model.MeOverviewModel.AssignmentModel Assignments,
        Clients.User.Model.MeOverviewModel.AchievementModel Achievements
    );

    private sealed record MonthlyTrend(uint Total, double Trending)
    {
        public static MonthlyTrend Empty(uint total) =>
            new(total, 0);

        public static MonthlyTrend Map(uint total, ExaminationModel current, ExaminationModel last) =>
            Map(total, current.Total, last.Total);

        public static MonthlyTrend Map(uint total, QuizModel current, QuizModel last) =>
            Map(total, current.Total, last.Total);

        public static MonthlyTrend Map(uint total, DateGuesserModel current, DateGuesserModel last) =>
            Map(total, current.Total, last.Total);

        private static MonthlyTrend Map(uint total, double current, double last)
        {
            var trending = Percentage.Calc(current - last, last);

            return new MonthlyTrend(total, trending);
        }
    }
}
