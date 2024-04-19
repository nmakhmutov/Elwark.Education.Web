using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.User;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MeOverviewModel = Education.Client.Features.History.Clients.Learner.Model.MeOverviewModel;

namespace Education.Client.Features.History.Pages.My.Dashboard;

using DateGuesserModel = MeOverviewModel.DateGuesserModel;
using ExaminationModel = MeOverviewModel.ExaminationModel;
using QuizModel = MeOverviewModel.QuizModel;

public sealed partial class Page
{
    private ApiResult<Aggregate> _result = ApiResult<Aggregate>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryUserClient UserClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [CascadingParameter]
    public CustomerState Customer { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var userRequest = await UserClient.GetMeAsync();
        if (userRequest.IsError)
        {
            _result = ApiResult<Aggregate>.Fail(userRequest.UnwrapError());
            return;
        }

        var learnerRequest = await LearnerClient.GetMeAsync();
        if (learnerRequest.IsError)
        {
            _result = ApiResult<Aggregate>.Fail(learnerRequest.UnwrapError());
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

        _result = ApiResult<Aggregate>.Success(
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
        Dictionary<InternalCurrency, long> Wallet,
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
            var trending = double.Round((current - last) / last * 100, 2) switch
            {
                double.NaN => 0,
                double.PositiveInfinity => 100,
                double.NegativeInfinity => -100,
                var x => x
            };

            return new MonthlyTrend(total, trending);
        }
    }
}
