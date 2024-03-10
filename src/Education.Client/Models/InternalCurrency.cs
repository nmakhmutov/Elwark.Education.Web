using System.Collections.Frozen;
using System.Diagnostics;

namespace Education.Client.Models;

public enum InternalCurrency
{
    Experience = 1,
    Coins = 2,
    Cash = 3
}

internal static class InternalCurrencyExtensions
{
    private static readonly FrozenDictionary<string, InternalCurrency> Values =
        new Dictionary<string, InternalCurrency>
            {
                [nameof(InternalCurrency.Experience)] = InternalCurrency.Experience,
                [nameof(InternalCurrency.Coins)] = InternalCurrency.Coins,
                [nameof(InternalCurrency.Cash)] = InternalCurrency.Cash
            }
            .ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

    public static InternalCurrency? ParseValueOrDefault(string value)
    {
        if (Values.TryGetValue(value, out var currency))
            return currency;

        return null;
    }

    public static string GetIcon(this InternalCurrency currency) =>
        currency switch
        {
            InternalCurrency.Experience => EduIcons.Experience,
            InternalCurrency.Coins => EduIcons.Coins,
            InternalCurrency.Cash => EduIcons.Cash,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(InternalCurrency)}")
        };
}
