using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record QuestModel(DailyBonusModel DailyBonus, DailyQuestModel DailyQuest, WeeklyQuestModel WeeklyQuest);
