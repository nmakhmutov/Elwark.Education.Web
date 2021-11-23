using System;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.Me;

public sealed record DailyReward(bool IsCollectable, DateTime NextTimeAt, IGameCurrency[] Rewards);
