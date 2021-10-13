using System;

namespace Education.Client.Gateways.History.Me;

public sealed record DailyReward(uint Points, bool IsCollectable, DateTime NextTimeAt);