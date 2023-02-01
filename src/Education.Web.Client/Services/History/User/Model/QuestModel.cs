using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record QuestModel(DailyBonusModel DailyBonus, DailyQuestModel DailyQuest, WeeklyQuestModel WeeklyQuest);
