using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.EventGuesser.Models;

public sealed record TestBuilder(
    TestRule Rule,
    HistoryUserRestriction Restriction,
    bool IsExistCurrent
);
