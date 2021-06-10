using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record UserLevel(
        uint Value,
        long Xp,
        long NextLevelXp,
        RecentXp[] Recent,
        DailyXp[] Daily,
        MonthlyXp[] Monthly
    );

    public sealed record RecentXp(XpType Type, long Value, DateTime CreatedAt);
    
    public sealed record DailyXp(DateTime Date, Dictionary<XpType, long> Values);

    public sealed record MonthlyXp(DateTime Date, long Value);
}
