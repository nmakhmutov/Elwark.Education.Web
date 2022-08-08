namespace Education.Web.Services.Model.Quest;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, IInternalMoney[] Rewards);