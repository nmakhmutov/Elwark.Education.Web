using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record MoneyActivityModel(
    DateOnly Date,
    InternalCurrency Currency,
    uint Income,
    uint Expense,
    long Balance
);
