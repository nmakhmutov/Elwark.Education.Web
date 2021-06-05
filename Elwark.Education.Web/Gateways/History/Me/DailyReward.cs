using System;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record DailyReward(uint Xp, bool IsCollectable, DateTime NextTimeAt);
}
