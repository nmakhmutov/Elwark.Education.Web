namespace Education.Client.Gateways.Models.User;

public sealed record DailyRewardModel(bool IsCollectable, DateTime? NextTimeAt, IInternalMoney[] Rewards);
