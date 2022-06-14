using System.Globalization;
using Blazored.LocalStorage;

namespace Education.Web.Services;

internal sealed class LanguageService
{
    private const string StorageKey = "ls";
    private readonly ILocalStorageService _storage;

    public LanguageService(ILocalStorageService storage) =>
        _storage = storage;

    public static Dictionary<string, string> Cultures =>
        new(2, StringComparer.InvariantCultureIgnoreCase)
        {
            ["en"] = "English",
            ["ru"] = "Русский"
        };

    public async Task<bool> SetAsync(string language)
    {
        if (!Cultures.ContainsKey(language))
            return false;

        await _storage.SetItemAsync(StorageKey, language);

        return true;
    }

    public async Task InitAsync()
    {
        var language = await _storage.GetItemAsync<string>(StorageKey) ?? Cultures.First().Key;
        var culture = new CultureInfo(language);

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
