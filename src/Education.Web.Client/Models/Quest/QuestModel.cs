namespace Education.Web.Client.Models.Quest;

public sealed record QuestModel(
    string Title,
    string Description,
    string IconUrl,
    uint Score,
    uint Threshold,
    bool IsCompleted,
    InternalMoneyModel[] Rewards
);
