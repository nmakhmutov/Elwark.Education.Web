namespace Education.Web.Client.Models.Quest;

public sealed record QuestsModel(QuestStatus Status, DateTime ExpiresAt, QuestModel[] Quests);
