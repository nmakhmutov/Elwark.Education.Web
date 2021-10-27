using System;

namespace Education.Client.Gateways.History.Me;

public sealed record UserStatistics(
    ScoreOverview EasyTest,
    ScoreOverview HardTest,
    ScoreOverview MixedTest,
    EventGuesserOverview EventGuesser,
    Experience[] Progress
);

public sealed record Experience(DateTime CreatedAt, uint Value);
