using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record WalletModel(InternalCurrency Currency, long Balance, WalletModel.BudgetModel[] Budgets)
{
    public sealed record BudgetModel(
        DateOnly Month,
        long Balance,
        uint Income,
        uint Expense,
        BudgetSourceModel[] Sources
    );

    public sealed record BudgetSourceModel(string Source, uint Income, uint Expense);
}
