using System;

namespace Education.Client.Gateways.History.Me;

public sealed record UserStatistics(
    ScoreOverview EasyTest,
    ScoreOverview HardTest,
    ScoreOverview MixedTest,
    EventGuesserOverview EventGuesser,
    Activity[] Activities
);

public sealed record Activity(DateTime Date, uint Total);
