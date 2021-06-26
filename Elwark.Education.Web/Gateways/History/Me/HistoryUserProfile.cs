using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record HistoryUserProfile(
        SubscriptionType Subscription,
        Restriction TestCreation,
        Restriction TestQuestionMistakes,
        Restriction DateGuesserCreation,
        float TestDurationCoefficient,
        UserExperience Experience,
        DailyReward DailyReward,
        CurrentTest[] CurrentTests
    );
}
