namespace Education.Web.Services.Model.Quest;

public sealed record QuestModel(string Title, uint Score, uint Threshold, bool IsCompleted);
