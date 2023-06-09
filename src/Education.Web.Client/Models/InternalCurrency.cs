using System.Diagnostics;

namespace Education.Web.Client.Models;

public enum InternalCurrency
{
    Experience = 1,
    Silver = 2
}

internal static class InternalCurrencyExtensions
{
    public static string GetIcon(this InternalCurrency currency) =>
        currency switch
        {
            InternalCurrency.Experience => EduIcons.Experience,
            InternalCurrency.Silver => EduIcons.Silver,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(InternalCurrency)}")
        };
}
