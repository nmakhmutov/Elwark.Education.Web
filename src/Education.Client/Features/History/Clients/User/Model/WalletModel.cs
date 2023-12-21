using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record WalletModel(InternalCurrency Currency, long Balance, WalletModel.Budget[] Budgets)
{
    public sealed record Budget(DateOnly Month, long Balance, uint Income, uint Expense);
}
