using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record UserExperience(
        uint Level,
        long Points,
        long NextLevelPoints,
        LevelTransaction[] Transactions
    );


    public sealed record LevelTransaction(ExperienceType Type, long Points, DateTime CreatedAt);

    public enum ExperienceType
    {
        TopicTestCompleted = 0,
        DailyReward = 1
    }
}
