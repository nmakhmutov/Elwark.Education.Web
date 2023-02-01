namespace Education.Web.Client.Models.Quest;

public sealed record QuestModel(string Title, uint Score, uint Threshold, bool IsCompleted);
