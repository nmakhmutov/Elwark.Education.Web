namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record BudgetModel(DateOnly Month, long Balance, uint Income, uint Expense);
