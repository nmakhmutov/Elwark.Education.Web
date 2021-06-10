using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record HistoryUserProfile(
        Subscription Subscription,
        Permission TestCreation,
        Permission TestQuestionMistakes,
        Permission TestQuestionDeletion,
        Permission DateGuesserCreation,
        float TestDurationCoefficient,
        UserLevel Level,
        DailyReward DailyReward,
        CurrentTest[] CurrentTests
    );
}
