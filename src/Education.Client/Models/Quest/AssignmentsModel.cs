namespace Education.Client.Models.Quest;

public sealed record AssignmentsModel(QuestStatus Status, DateTime ExpiresAt, QuestModel[] Assignments);