using System;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record UserRank(
        uint Level,
        long Xp,
        long NextLevelXp,
        Xp[] Recent
    );

    public sealed record Xp(XpType Type, long Value, DateTime CreatedAt);
}
