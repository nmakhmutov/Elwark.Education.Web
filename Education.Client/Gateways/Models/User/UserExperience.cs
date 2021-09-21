using System;

namespace Education.Client.Gateways.Models.User
{
    public sealed record UserExperience(
        uint Level,
        long Points,
        long NextLevelPoints,
        TypedExperience[] Recent,
        Experience[] Daily
    );

    public sealed record TypedExperience(ExperienceName Type, long Points, DateTime CreatedAt);

    public sealed record Experience(long Points, DateTime CreatedAt);
}
