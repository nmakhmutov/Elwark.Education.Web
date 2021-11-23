using System;

namespace Education.Client.Gateways.History.Me;

public sealed record UserStatistics(
    ScoreOverview EasyTest,
    ScoreOverview HardTest,
    ScoreOverview MixedTest,
    EventGuesserOverview EventGuesser,
    ActivityOverview[] Activities
);

public sealed record ActivityOverview(DateTime Date, uint Total);
