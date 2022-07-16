namespace Education.Web.Gateways.Models.User;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, IInternalMoney[] Rewards);
