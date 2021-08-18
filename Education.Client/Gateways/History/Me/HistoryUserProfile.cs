using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Me
{
    public sealed record HistoryUserProfile(
        SubscriptionType Subscription,
        Restriction TestCreation,
        Restriction TestQuestionMistakes,
        Restriction DateGuesserCreation,
        float TestDurationCoefficient,
        UserStatistics Statistics,
        UserExperience Experience,
        DailyReward DailyReward,
        CurrentTest[] CurrentTests
    );
}
