using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record UserAssignmentModel(
    DailyBonusModel DailyBonus,
    AssignmentsModel DailyAssignments,
    AssignmentsModel WeeklyAssignments
);