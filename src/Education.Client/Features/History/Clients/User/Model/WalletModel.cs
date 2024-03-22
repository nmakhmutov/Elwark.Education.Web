using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record WalletModel(InternalCurrency Currency, long Balance, WalletModel.BudgetModel[] Budgets)
{
    public sealed record BudgetModel(
        DateOnly Month,
        uint Income,
        uint Expense,
        long Balance,
        BudgetSourceModel[] Sources
    );

    public sealed record BudgetSourceModel(string Title, uint Income, uint Expense, long Balance);
}