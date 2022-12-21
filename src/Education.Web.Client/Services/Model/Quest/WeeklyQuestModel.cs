namespace Education.Web.Client.Services.Model.Quest;

public sealed record WeeklyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);
