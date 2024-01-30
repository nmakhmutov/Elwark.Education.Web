namespace Education.Client.Features.History.Clients.User.Model;

public sealed record UserAssignmentModel(
    DailyBonusModel DailyBonus,
    QuestModel[] DailyAssignments,
    QuestModel[] WeeklyAssignments
);
