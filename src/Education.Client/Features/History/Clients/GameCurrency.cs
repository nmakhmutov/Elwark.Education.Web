using System.Diagnostics;

namespace Education.Client.Features.History.Clients;

public enum GameCurrency
{
    Denarius = 1
}

internal static class GameCurrencyExtensions
{
    public static GameCurrency? ParseValueOrDefault(string value)
    {
        if (nameof(GameCurrency.Denarius).Equals(value, StringComparison.OrdinalIgnoreCase))
            return GameCurrency.Denarius;

        return null;
    }

    public static string GetIcon(this GameCurrency currency) =>
        currency switch
        {
            GameCurrency.Denarius => EduIcons.Denarius,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(GameCurrency)}")
        };
}
