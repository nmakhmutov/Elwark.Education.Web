using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.History.User;

public sealed record DailyReward(bool IsCollectable, DateTime NextTimeAt, IGameCurrency[] Rewards);
