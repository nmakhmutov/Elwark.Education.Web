namespace Education.Web.Client.Models.Quest;

public sealed record WeeklyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);
