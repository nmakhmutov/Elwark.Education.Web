using Education.Web.Client.Services.Model.Quest;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record QuestModel(DailyBonusModel DailyBonus, DailyQuestModel DailyQuest, WeeklyQuestModel WeeklyQuest);
