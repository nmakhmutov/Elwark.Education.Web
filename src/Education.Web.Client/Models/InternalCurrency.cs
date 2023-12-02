using System.Diagnostics;

namespace Education.Web.Client.Models;

public enum InternalCurrency
{
    Experience = 1,
    Scroll = 2,
    Book = 3
}

internal static class InternalCurrencyExtensions
{
    public static string GetIcon(this InternalCurrency currency) =>
        currency switch
        {
            InternalCurrency.Experience => EduIcons.Experience,
            InternalCurrency.Scroll => EduIcons.Scroll,
            InternalCurrency.Book => EduIcons.Book,
            _ => throw new UnreachableException($"Unknown type {currency} of {nameof(InternalCurrency)}")
        };
}
