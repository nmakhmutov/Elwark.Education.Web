namespace Education.Client.Features.History.Clients.User.Model;

public sealed record FinanceModel(WalletModel[] Wallets, MoneyActivityModel[] Activities);
