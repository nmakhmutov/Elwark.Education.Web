namespace Education.Client.Models.Quest;

public sealed record DailyBonusModel(bool IsCollectable, DateTime? NextTimeAt, InternalMoneyModel[] Rewards);
