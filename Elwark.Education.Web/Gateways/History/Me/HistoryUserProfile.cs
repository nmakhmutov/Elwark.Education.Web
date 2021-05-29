using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.History.Me
{
    internal sealed record HistoryUserProfile(
        Subscription Subscription,
        Restriction TestCreation,
        Restriction AnswerCreation,
        float TestTimeCoefficient,
        bool IsAllowedPremiumContent,
        UserExperience Experience,
        CurrentTest[] CurrentTests
    );
}
