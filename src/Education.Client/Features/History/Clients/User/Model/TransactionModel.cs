using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record TransactionModel(
    DateTime Date,
    string Title,
    TransactionKind Kind,
    IEnumerable<InternalMoneyModel> Monies
);

public enum TransactionKind
{
    Unknown = 0,
    Income = 1,
    Expense = 2,
}
