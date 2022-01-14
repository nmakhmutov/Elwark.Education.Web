using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History;

public sealed record HistoryUserRestriction(
    UserTestPermission TestCreation,
    UserSimplePermission TestMistakes,
    UserSimplePermission EventGuesser
);
