using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Me
{
    public sealed record HistoryUserRestriction(
        TestPermission TestCreation,
        SimplePermission TestMistakes,
        SimplePermission EventGuesser
    );
}
