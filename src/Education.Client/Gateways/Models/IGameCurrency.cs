namespace Education.Client.Gateways.Models;

public interface IGameCurrency
{
}

public sealed record ExperienceCurrency(ulong Value) : IGameCurrency;

public sealed record SilverCurrency(long Value) : IGameCurrency;
