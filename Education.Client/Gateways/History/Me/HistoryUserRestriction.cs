using Education.Client.Gateways.Models.Test;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Me
{
    public sealed record HistoryUserRestriction(
        TestStatus TestStatus,
        Restriction TestCreation,
        Restriction TestMistakes,
        Restriction EventGuesserCreation
    );
}
