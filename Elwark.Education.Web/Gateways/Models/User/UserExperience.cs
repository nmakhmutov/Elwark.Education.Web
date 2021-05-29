using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    internal sealed record UserExperience(
        uint Level,
        long Points,
        long NextLevelPoints,
        LevelTransaction[] Transactions
    );

    internal sealed record LevelTransaction(ExperienceType Type, long Points, DateTime CreatedAt);
}
