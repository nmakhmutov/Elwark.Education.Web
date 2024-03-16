using System.Collections.Frozen;
using System.Diagnostics;

namespace Education.Client.Models;

public enum InternalCurrency
{
    Experience = 1,
    Denarius = 2,
    Solidus = 3
}

internal static class InternalCurrencyExtensions
{
    private static readonly FrozenDictionary<string, InternalCurrency> Values =
        new Dictionary<string, InternalCurrency>
            {
                [nameof(InternalCurrency.Experience)] = InternalCurrency.Experience,
                [nameof(InternalCurrency.Denarius)] = InternalCurrency.Denarius,
                [nameof(InternalCurrency.Solidus)] = InternalCurrency.Solidus
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
            InternalCurrency.Denarius => EduIcons.Denarius,
            InternalCurrency.Solidus => EduIcons.Solidus,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(InternalCurrency)}")
        };
}
