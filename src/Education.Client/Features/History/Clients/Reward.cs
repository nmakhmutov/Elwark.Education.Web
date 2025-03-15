using System.Text.Json.Serialization;

namespace Education.Client.Features.History.Clients;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "_t"),
 JsonDerivedType(typeof(ExperienceModel), "experience"),
 JsonDerivedType(typeof(MoneyModel), "money")]
public abstract record Reward
{
    public sealed record ExperienceModel(uint Amount) : Reward;

    public sealed record MoneyModel(GameCurrency Currency, uint Amount) : Reward;
}
