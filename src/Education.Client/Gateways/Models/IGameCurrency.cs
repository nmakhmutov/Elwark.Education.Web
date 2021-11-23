namespace Education.Client.Gateways.Models;

public interface IGameCurrency
{
}

public sealed record ExperienceCurrency(uint Value) : IGameCurrency;

public sealed record SilverCurrency(int Value) : IGameCurrency;
