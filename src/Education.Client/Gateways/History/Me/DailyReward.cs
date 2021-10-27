using System;

namespace Education.Client.Gateways.History.Me;

public sealed record DailyReward(uint Experience, bool IsCollectable, DateTime NextTimeAt);
