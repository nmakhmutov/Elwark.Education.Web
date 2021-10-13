namespace Education.Client.Gateways.History.Test;

public sealed record TestBuilder(TestRule Rule, HistoryUserRestriction Restriction, CurrentTest[] CurrentTests);
