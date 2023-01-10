namespace Education.Web.Client.Services.Model.User;

public sealed record LevelModel(uint Value, ulong Experience, ulong NextLevelExperience, BudgetModel[] Accounting);
