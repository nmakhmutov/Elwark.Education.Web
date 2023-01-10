namespace Education.Web.Client.Services.Model.User;

public sealed record BudgetModel(DateOnly Month, long Balance, uint Income, uint Expense);
