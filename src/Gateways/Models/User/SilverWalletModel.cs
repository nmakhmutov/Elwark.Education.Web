namespace Education.Web.Gateways.Models.User;

public sealed record SilverWalletModel(long Balance, SilverWalletModel.CashFlow Flow)
{
    public sealed record CashFlow(DateOnly Month, int Income, int Expense);
}
