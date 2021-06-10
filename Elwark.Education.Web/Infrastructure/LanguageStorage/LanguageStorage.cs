using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Elwark.Education.Web.Infrastructure.LanguageStorage
{
    public class LanguageStorage : ILanguageStorage
    {
        private readonly ILocalStorageService _storage;

        public LanguageStorage(ILocalStorageService storage) =>
            _storage = storage;

        public ValueTask SetAsync(string language) =>
            _storage.SetItemAsync("language", language);
    }
}
