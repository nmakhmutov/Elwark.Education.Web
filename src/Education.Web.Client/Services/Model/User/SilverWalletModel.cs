namespace Education.Web.Client.Services.Model.User;

public sealed record SilverWalletModel(long Balance, SilverWalletModel.CashFlow[] Flow)
{
    public sealed record CashFlow(DateOnly Month, long Balance, int Income, int Expense);
}
