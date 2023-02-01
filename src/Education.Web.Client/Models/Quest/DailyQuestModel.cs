namespace Education.Web.Client.Models.Quest;

public sealed record DailyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);
