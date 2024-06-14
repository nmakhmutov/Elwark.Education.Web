using System.Collections.Frozen;
using System.Diagnostics;

namespace Education.Client.Features.History.Clients;

public enum GameCurrency
{
    Denarius = 1,
    Solidus = 2
}

internal static class GameCurrencyExtensions
{
    private static readonly FrozenDictionary<string, GameCurrency> Values =
        new Dictionary<string, GameCurrency>
            {
                [nameof(GameCurrency.Denarius)] = GameCurrency.Denarius,
                [nameof(GameCurrency.Solidus)] = GameCurrency.Solidus
            }
            .ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

    public static GameCurrency? ParseValueOrDefault(string value)
    {
        if (Values.TryGetValue(value, out var currency))
            return currency;

        return null;
    }

    public static string GetIcon(this GameCurrency currency) =>
        currency switch
        {
            GameCurrency.Denarius => EduIcons.Denarius,
            GameCurrency.Solidus => EduIcons.Solidus,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(GameCurrency)}")
        };
}
