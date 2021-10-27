using System;

namespace Education.Client.Gateways.Models.User;

public sealed record UserProfile(
    uint Level,
    ulong Experience,
    ulong NextLevelExperience,
    long Balance,
    Experience[] Transactions
);

public sealed record Experience(ExperienceType Type, uint Value, DateTime CreatedAt, string? Comment);

public enum ExperienceType
{
    LevelUp = 0,
    DailyReward = 1,
    EasyTest = 2,
    HardTest = 3,
    MixedTest = 4,
    EventGuesser = 5,
    Achievement = 6
}
