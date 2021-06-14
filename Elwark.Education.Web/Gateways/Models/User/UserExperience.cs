using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record UserExperience(
        uint Level,
        long Points,
        long PointsToNextLevel,
        RecentExperience[] Recent,
        DailyExperience[] Daily,
        MonthlyExperience[] Monthly
    );

    public sealed record RecentExperience(ExperienceName Type, long Value, DateTime CreatedAt);
    
    public sealed record DailyExperience(DateTime Date, Dictionary<ExperienceName, long> Values);

    public sealed record MonthlyExperience(DateTime Date, long Value);
}
