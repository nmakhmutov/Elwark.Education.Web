using Education.Client.Models.Quest;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record UserAssignmentModel(
    DailyBonusModel DailyBonus,
    AssignmentsModel DailyAssignments,
    AssignmentsModel WeeklyAssignments
);
