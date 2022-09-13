namespace Education.Web.Services.Model.Quest;

public sealed record WeeklyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);
