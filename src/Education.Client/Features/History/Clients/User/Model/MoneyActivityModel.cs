namespace Education.Client.Features.History.Clients.User.Model;

public sealed record MoneyActivityModel(
    DateOnly Day,
    GameCurrency Currency,
    uint Income,
    uint Expense,
    long Balance
);
