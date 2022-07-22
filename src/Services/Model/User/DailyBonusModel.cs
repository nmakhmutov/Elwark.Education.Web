namespace Education.Web.Services.Model.User;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, IInternalMoney[] Rewards);
