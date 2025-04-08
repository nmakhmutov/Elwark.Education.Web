using Education.Client.Features.History.Clients.Order.Model;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record FinanceModel(
    WalletDetailsModel[] Wallets,
    MoneyActivityModel[] Activities,
    OrderModel[] Orders,
    TransactionModel[] Transactions
);
