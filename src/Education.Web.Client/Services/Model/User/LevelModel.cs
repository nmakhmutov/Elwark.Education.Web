namespace Education.Web.Client.Services.Model.User;

public sealed record LevelModel(uint Rank, ulong Experience, ulong Threshold, BudgetModel[] Accounting);
