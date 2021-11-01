using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Me;

public sealed record HistoryUserProfile(
    SubscriptionType Subscription,
    Restriction TestCreation,
    Restriction TestMistakes,
    Restriction EventGuesser,
    float TestDurationCoefficient,
    UserStatistics Statistics,
    UserProfile Profile,
    DailyReward DailyReward,
    AchievementsOverview Achievements
);
