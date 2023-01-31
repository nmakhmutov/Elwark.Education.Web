using System.Collections.Concurrent;
using System.Globalization;
using Education.Http.Resources.Languages;

namespace Education.Http.Resources;

internal sealed class LanguageManager : ILanguageManager
{
    private readonly ConcurrentDictionary<string, string?> _languages = new();

    public string GetString(string resource) =>
        GetString(resource, CultureInfo.CurrentCulture);

    public string GetString(string resource, CultureInfo culture) =>
        _languages.GetOrAdd(GetKey(culture.Name, resource), _ => GetTranslation(culture.Name, resource))
        ?? _languages.GetOrAdd(GetKey(EnglishLanguage.Culture, resource), _ => EnglishLanguage.GetTranslation(resource))
        ?? resource;

    public string GetString(string resource, CultureInfo culture, params object?[] args) =>
        string.Format(GetString(resource, culture), args);

    private static string? GetTranslation(string culture, string key) =>
        culture switch
        {
            EnglishLanguage.Culture => EnglishLanguage.GetTranslation(key),
            RussianLanguage.Culture => RussianLanguage.GetTranslation(key),
            _ => null
        };

    private static string GetKey(string culture, string key) =>
        $"{culture}:{key}";
}
