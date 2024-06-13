using System.Text.Json.Serialization;

namespace Education.Client.Features.History.Clients;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type"),
 JsonDerivedType(typeof(ExperienceModel), "experience"),
 JsonDerivedType(typeof(MoneyModel), "money")]
public abstract record Reward
{
    public sealed record ExperienceModel(uint Amount) : Reward;

    public sealed record MoneyModel(InternalCurrency Currency, uint Amount) : Reward;
}
