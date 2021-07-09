using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Elwark.Education.Web.Infrastructure.Services
{
    public sealed class LanguageService
    {
        private const string StorageKey = "ls";
        private readonly ILocalStorageService _storage;

        public LanguageService(ILocalStorageService storage) =>
            _storage = storage;

        public static Dictionary<string, string> Cultures => new(3, StringComparer.InvariantCultureIgnoreCase)
        {
            ["en-us"] = "English (US)",
            ["en-gb"] = "English (UK)",
            ["ru-ru"] = "Русский"
        };

        public static string Language => CultureInfo.CurrentCulture.Name;

        public static string Name => Cultures.TryGetValue(CultureInfo.CurrentCulture.Name, out var language)
            ? language
            : Cultures.First().Value;

        public async Task<bool> SetAsync(string language)
        {
            if (!Cultures.ContainsKey(language)) 
                return false;
            
            await _storage.SetItemAsync(StorageKey, language);
            return true;
        }
    }
}
