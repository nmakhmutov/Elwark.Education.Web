using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record WalletModel(InternalCurrency Currency, long Balance, WalletModel.Budget[] Budgets)
{
    public sealed record Budget(DateOnly Month, long Balance, uint Income, uint Expense);
}
