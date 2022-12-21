namespace Education.Web.Client.Services.Model.Quest;

public sealed record QuestModel(string Title, uint Score, uint Threshold, bool IsCompleted);
