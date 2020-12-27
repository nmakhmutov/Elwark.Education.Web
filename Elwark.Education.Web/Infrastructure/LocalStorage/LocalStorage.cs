using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Elwark.Education.Web.Infrastructure.LocalStorage
{
    public class LocalStorage : ILocalStorage
    {
        private readonly ILocalStorageService _storage;

        public LocalStorage(ILocalStorageService storage) =>
            _storage = storage;

        public ValueTask SetLanguageAsync(string language) =>
            _storage.SetItemAsync("language", language);
    }
}