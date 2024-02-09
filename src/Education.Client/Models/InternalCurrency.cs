using System.Collections.Frozen;
using System.Diagnostics;

namespace Education.Client.Models;

public enum InternalCurrency
{
    Experience = 1,
    Scroll = 2,
    Book = 3
}

internal static class InternalCurrencyExtensions
{
    private static readonly FrozenDictionary<string, InternalCurrency> Values =
        new Dictionary<string, InternalCurrency>
            {
                [nameof(InternalCurrency.Experience)] = InternalCurrency.Experience,
                [nameof(InternalCurrency.Scroll)] = InternalCurrency.Scroll,
                [nameof(InternalCurrency.Book)] = InternalCurrency.Book
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
            InternalCurrency.Scroll => EduIcons.Scroll,
            InternalCurrency.Book => EduIcons.Book,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(InternalCurrency)}")
        };
}
