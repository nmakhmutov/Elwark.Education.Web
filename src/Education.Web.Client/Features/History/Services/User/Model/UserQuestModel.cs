using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record UserQuestModel(DailyBonusModel DailyBonus, QuestsModel DailyQuests, QuestsModel WeeklyQuests);
