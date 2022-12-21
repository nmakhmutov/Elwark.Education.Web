namespace Education.Web.Client.Services.Model.Quest;

public sealed record DailyQuestModel(
    QuestStatus Status,
    DateTime? ExpiresAt,
    QuestModel[] Quests,
    IInternalMoney[] Rewards
);