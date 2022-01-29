namespace Education.Client.Gateways.Models;

public interface IVirtualCurrency
{
}

public sealed record UserExperience(ulong Value) : IVirtualCurrency;

public sealed record SilverCurrency(long Value) : IVirtualCurrency;
