namespace Education.Web.Services.Model.Quest;

public sealed record DailyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);