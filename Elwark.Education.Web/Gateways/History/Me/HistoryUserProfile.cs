using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record HistoryUserProfile(
        Subscription Subscription,
        Restriction TestCreation,
        Restriction AnswerCreation,
        float TestTimeCoefficient,
        bool IsAllowedPremiumContent,
        UserRank Rank,
        DailyReward DailyReward,
        CurrentTest[] CurrentTests
    );
}
