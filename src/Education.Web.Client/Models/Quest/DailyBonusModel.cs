namespace Education.Web.Client.Models.Quest;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, IInternalMoney[] Rewards);
