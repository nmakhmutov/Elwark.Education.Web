namespace Education.Client.Features.History.Clients.User.Model;

public sealed record FinanceModel(
    WalletDetailsModel[] Wallets,
    MoneyActivityModel[] Activities,
    TransactionModel[] Transactions
);
