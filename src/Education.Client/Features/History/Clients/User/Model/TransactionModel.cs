using System.Text.Json.Serialization;

namespace Education.Client.Features.History.Clients.User.Model;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(Income), "income"),
 JsonDerivedType(typeof(Expense), "expense")]
public abstract record TransactionModel(string Title, DateTime CreatedAt, IEnumerable<GameMoneyModel> Monies)
{
    public sealed record Income(DateTime CreatedAt, string Title, IEnumerable<GameMoneyModel> Monies)
        : TransactionModel(Title, CreatedAt, Monies);

    public sealed record Expense(DateTime CreatedAt, string Title, IEnumerable<GameMoneyModel> Monies)
        : TransactionModel(Title, CreatedAt, Monies);
}
