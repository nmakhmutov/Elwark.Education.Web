using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryUserProfile(
        UserExperience Experience,
        Subject Subject,
        CurrentTest[] CurrentTests
    );
}
