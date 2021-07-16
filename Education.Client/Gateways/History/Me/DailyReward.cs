using System;

namespace Education.Client.Gateways.History.Me
{
    public sealed record DailyReward(uint Xp, bool IsCollectable, DateTime NextTimeAt);
}
