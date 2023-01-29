namespace Education.Web.Client.Services.History.User.Model;

public sealed record BudgetModel(DateOnly Month, long Balance, uint Income, uint Expense);
